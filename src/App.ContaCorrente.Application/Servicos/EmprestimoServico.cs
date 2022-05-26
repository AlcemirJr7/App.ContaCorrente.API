using App.ContaCorrente.Application.CQRS.Emprestimos.Commands;
using App.ContaCorrente.Application.CQRS.Emprestimos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Servicos
{
    public class EmprestimoServico : IEmprestimoServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        private readonly ILocalTrabalhoRepositorio _localTrabalhoRepositorio;
        private readonly IEmprestimoRepositorio _emprestimoRepositorio; 
        public EmprestimoServico(IMediator mediator, IMapper mapper, ICorrentistaRepositorio correntistaRepositorio, 
                                 ILocalTrabalhoRepositorio localTrabalhoRepositorio, IEmprestimoRepositorio emprestimoRepositorio)
        {
            _mediator = mediator;
            _mapper = mapper;
            _correntistaRepositorio = correntistaRepositorio;
            _localTrabalhoRepositorio = localTrabalhoRepositorio;
            _emprestimoRepositorio = emprestimoRepositorio;

        }

        public async Task<EmprestimoDTO> AlterarAsync(EmprestimoDTO emprestimoDto)
        {
            var emprestimoAlterarCommand = _mapper.Map<EmprestimoEfetivarCommand>(emprestimoDto);
            var result = await _mediator.Send(emprestimoAlterarCommand);
            var emprestimo = _mapper.Map<EmprestimoDTO>(result);

            return emprestimo;
        }

        public async Task<EmprestimoEfetivarDTO> EfetivarEmprestimoAsync(int? id)
        {
            var emprestimoQuery = await _emprestimoRepositorio.GetPeloIdAsync(id.Value);
            
            var emprestimoEfetivarCommand = _mapper.Map<EmprestimoEfetivarCommand>(emprestimoQuery);
            var result = await _mediator.Send(emprestimoEfetivarCommand);
            var emprestimo = _mapper.Map<EmprestimoEfetivarDTO>(result);

            return emprestimo;
        }

        public async Task<EmprestimoDTO> CriarAsync(EmprestimoDTO emprestimoDto)
        {
            var emprestimoCriarCommand = _mapper.Map<EmprestimoCriarCommand>(emprestimoDto);
            var result = await _mediator.Send(emprestimoCriarCommand);
            var emprestimo = _mapper.Map<EmprestimoDTO>(result);

            return emprestimo;
        }
        
        public decimal CalculaParcelaEmprestimo(decimal valor, int qtdParcelas, decimal juros)
        {
            // calculo com base na tabela price
            var taxaY = (juros / 100);
            var taxaX = (decimal)Math.Pow((double)(1 + taxaY), qtdParcelas);
            var taxaZ = (taxaX * taxaY) / (taxaX - 1);
            var valorParcela = valor * taxaZ;

            return Math.Round(valorParcela,2);

        }

        //private decimal GetTaxaAnual(decimal juros)
        //{

        //    decimal taxaX = (juros/100);
        //    decimal taxaY = (decimal)Math.Pow((double)(1 + taxaX),12);
        //    decimal taxaZ = taxaY - 1;
        //    decimal taxaAnual = Math.Round(taxaZ, 4) * 100;            

        //    return Math.Round(taxaAnual,2);
        //}

        public async Task<bool> AnaliseCreditoCorrentistaAsync(int? correntistaId, decimal valorParcela)
        {
            var correntista = await _correntistaRepositorio.GetPeloIdAsync(correntistaId);

            if (correntista == null)
            {
                throw new DomainException(Mensagens.CorrentistaInvalido);
            }

            var emprestimos = await _emprestimoRepositorio.GetEmprestimosEfetivadosPeloCorrentistaIdAsync(correntistaId);

            decimal valorParcelasEmprestimos = decimal.Zero;

            //calculo o valor das parcelas dos emprestimos já efetivados
            foreach (var item in emprestimos)
            {
                valorParcelasEmprestimos = valorParcelasEmprestimos + item.ValorParcela;
            }
                        
            var localTrabalho = await _localTrabalhoRepositorio.GetPeloIdAsync(correntista.LocalTrabalhoId);

            if (localTrabalho == null)
            {
                throw new DomainException(Mensagens.LocalTrabalhoInvalido);
            }

            decimal percentual = (decimal)EnumEmprestimoPercentualSalario.Percentual;

            var valorAvalCorrentista = (localTrabalho.Salario1 + localTrabalho.Salario2.Value);
            var percAval = (percentual / 100);
            valorAvalCorrentista = Math.Round(valorAvalCorrentista * percAval,2);

            if ((valorParcelasEmprestimos + valorParcela) > valorAvalCorrentista)
            {
                return false;
            }
            else
            {
                return true;
            }            
            
        }
                
        public async Task<IEnumerable<EmprestimoDTO>> GetPeloCorrentistaIdAsync(int? id)
        {
            var enderecoQuery = new GetEmprestimosPeloCorrentistaIdQuery(id.Value);

            if (enderecoQuery == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
            else
            {
                var result = await _mediator.Send(enderecoQuery);

                return _mapper.Map<IEnumerable<EmprestimoDTO>>(result);
            }
        }

        public async Task<EmprestimoDTO> GetPeloIdAsync(int? id)
        {
            var enderecoQuery = new GetEmprestimoPeloIdQuery(id.Value);

            if (enderecoQuery == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
            else
            {
                var result = await _mediator.Send(enderecoQuery);

                return _mapper.Map<EmprestimoDTO>(result);
            }
        }
    }
}
