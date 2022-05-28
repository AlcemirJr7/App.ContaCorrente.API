using App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Commands;
using App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class ParcelasEmprestimoServico : IParcelasEmprestimoServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ParcelasEmprestimoServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public Task<ParcelasEmprestimoDTO> AlterarAsync(ParcelasEmprestimoDTO parcelasEmprestimoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ParcelasEmprestimoDTO>> GetPeloEmprestimoIdAsync(int? id)
        {
            var parcelasQuery = new GetParcelasEmprestimoPeloEmprestimoIdQuery(id.Value);

            if(parcelasQuery == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            var result = await _mediator.Send(parcelasQuery);

            var parcelas = _mapper.Map<IEnumerable<ParcelasEmprestimoDTO>>(result);

            return parcelas;

        }

        public async Task<IEnumerable<ParcelasEmprestimoDTO>> ProcessaPagamentoParcelaEmprestimo()
        {
            var parcelaEmprestimoCommand = new ParcelasEmprestimoPagarCommand();

            var result = await _mediator.Send(parcelaEmprestimoCommand);

            var parcelasEmprestimo = _mapper.Map<IEnumerable<ParcelasEmprestimoDTO>>(result);

            return parcelasEmprestimo;
        }

        public Task<IEnumerable<ParcelasEmprestimoDTO>> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParcelasEmprestimoDTO> GerarParcelasEmprestimo(Emprestimo emprestimo)
        {
            List<ParcelasEmprestimoDTO> listaParcelas  = new  List<ParcelasEmprestimoDTO>();

            try
            {
                var dataVencimento = Convert.ToDateTime(emprestimo.DataEfetivacao.Value.ToString("dd/MM/yyyy")).AddMonths(1);

                for (int i = 0; i < emprestimo.QtdParcelas; i++)
                {
                    var parcela = new ParcelasEmprestimoDTO
                    {
                        SeqParcelas = i + 1,
                        DataVencimento = dataVencimento,
                        EmprestimoId = emprestimo.Id,
                        Valor = emprestimo.ValorParcela                        
                    };        

                    listaParcelas.Add(parcela);

                    dataVencimento = dataVencimento.AddMonths(1);
                }
                
                return listaParcelas;

            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarParcelasEmprestimo);
            }
        }
    }
}
