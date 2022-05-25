using App.ContaCorrente.Application.CQRS.Emprestimos.Commands;
using App.ContaCorrente.Application.CQRS.Emprestimos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
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
        public EmprestimoServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public Task<EmprestimoDTO> AlterarAsync(EmprestimoDTO emprestimoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<EmprestimoDTO> CriarAsync(EmprestimoDTO emprestimoDto)
        {
            var emprestimoCriarCommand = _mapper.Map<EmprestimoCriarCommand>(emprestimoDto);
            var result = await _mediator.Send(emprestimoCriarCommand);
            var emprestimo = _mapper.Map<EmprestimoDTO>(result);

            return emprestimo;
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
