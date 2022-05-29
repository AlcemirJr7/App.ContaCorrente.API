using App.ContaCorrente.Application.CQRS.LancamentosFuturos.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.LancamentosFuturos.Handlers
{
    public class LancamentoFuturoCancelarCommandHandler : IRequestHandler<LancamentoFuturoCancelarCommand, LancamentoFuturo>
    {
        private readonly ILancamentoFuturoRepositorio _lancamentoFuturoRepositorio;
        public LancamentoFuturoCancelarCommandHandler(ILancamentoFuturoRepositorio lancamentoFuturoRepositorio)
        {
            _lancamentoFuturoRepositorio = lancamentoFuturoRepositorio;
        }

        public async Task<LancamentoFuturo> Handle(LancamentoFuturoCancelarCommand request, CancellationToken cancellationToken)
        {
            

            try
            {
                var lancamentoFuturo = await _lancamentoFuturoRepositorio.GetPeloIdAsync(request.Id);

                lancamentoFuturo.Atualizar(lancamentoFuturo.Valor,lancamentoFuturo.DataCadastro,lancamentoFuturo.DataParaLancamento,lancamentoFuturo.TipoLancamento,
                                          lancamentoFuturo.FlagLancamento,lancamentoFuturo.DataLancamento,lancamentoFuturo.Observacao,lancamentoFuturo.IdDoLancamento,
                                          EnumSituacaoLancamentoFuturo.Cancelado,lancamentoFuturo.HistoricoId,lancamentoFuturo.CorrentistaId);

                return await _lancamentoFuturoRepositorio.AlterarAsync(lancamentoFuturo);

            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
            catch (DomainExcepitonValidacao e)
            {
                throw new DomainExcepitonValidacao(e.Message);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoAlterarLancamentoFuturo);
            }
            
        }
    }
}
