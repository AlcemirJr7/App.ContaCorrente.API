using App.ContaCorrente.Application.CQRS.LancamentosFuturos.Commands;
using App.ContaCorrente.Application.CQRS.LancamentosFuturos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class LancamentoFuturoServico : ILancamentoFuturoServico
    {

        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IPagamentoRepositorio _pagamentoRepositorio;

        public LancamentoFuturoServico(IMediator mediator, IMapper mapper, IPagamentoRepositorio pagamentoRepositorio)
        {
            _mediator = mediator;
            _mapper = mapper;
            _pagamentoRepositorio = pagamentoRepositorio;
        }

        public async Task AtualizaLancamentoFuturoPagamento(int? id)
        {
            var pagamento = await _pagamentoRepositorio.GetPeloIdAsync(id.Value);

            if (pagamento == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(Pagamento)));
            }
            else
            {
                pagamento.Atualizar(pagamento.CodigoBarra,pagamento.NumeroDocumento,pagamento.DataGeracao,pagamento.Valor,
                                    pagamento.DataVencimento,DateTime.Now,pagamento.DataAgendamento,pagamento.CorrentistaId);

                await _pagamentoRepositorio.AtualizarAsync(pagamento);
            }
            
        }

        public async Task<LancamentoFuturoDTO> CriarAsync(LancamentoFuturoDTO lancamentoFuturoDto)
        {
            var lancamentoFuturoCommand = _mapper.Map<LancamentoFuturoCriarCommand>(lancamentoFuturoDto);

            var result = await _mediator.Send(lancamentoFuturoCommand);

            var lancamentoFuturo = _mapper.Map<LancamentoFuturoDTO>(result);

            return lancamentoFuturo;

        }

        public async Task<IEnumerable<LancamentoFuturoDTO>> GetPeloCorrentistaIdAsync(int? id)
        {
            var lancamentoQuery = new GetLancamentoFuturoPeloCorrentistaIdQuery(id.Value);

            if (lancamentoQuery == null)
            {

                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Lancamento)));
            }

            var result = await _mediator.Send(lancamentoQuery);

            return _mapper.Map<IEnumerable<LancamentoFuturoDTO>>(result);
        }

        public async Task<LancamentoFuturoDTO> GetPeloIdAsync(int? id)
        {
            var lancamentoQuery = new GetLancamentoFuturoPeloIdQuery(id.Value);

            if (lancamentoQuery == null){

                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Lancamento)));
            }

            var result = await _mediator.Send(lancamentoQuery);

            return _mapper.Map<LancamentoFuturoDTO>(result);
        }

        public async Task<IEnumerable<LancamentoFuturoDTO>> ProcessaLancamentosFuturos()
        {
            var lancamentoFuturoCommand = new LancamentoFuturoEfetivarCommand();

            var result = await _mediator.Send(lancamentoFuturoCommand);

            var lancamentoFuturo = _mapper.Map<IEnumerable<LancamentoFuturoDTO>>(result);

            return lancamentoFuturo;

        }
        
    }
}
