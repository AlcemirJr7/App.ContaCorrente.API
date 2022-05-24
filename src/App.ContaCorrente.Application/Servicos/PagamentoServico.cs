using App.ContaCorrente.Application.CQRS.Pagamentos.Commands;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class PagamentoServico : IPagamentoServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;               
        public PagamentoServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;            
        }

        public async Task<PagamentoDTO> CriarAsync(PagamentoDTO pagamentoDto)
        {
            var pagamentoCriarCommand = _mapper.Map<PagamentoCriarCommand>(pagamentoDto);
                                  
            var result = await _mediator.Send(pagamentoCriarCommand);
            var pagamento = _mapper.Map<PagamentoDTO>(result);
                       
            return pagamento;
                                                            
        }

        public Task<IEnumerable<PagamentoDTO>> GetPeloCorrentistaIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<PagamentoDTO> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
