using App.ContaCorrente.Application.CQRS.SaldoContaCorrentes.Queries;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.SaldoContaCorrentes.Handlers
{
    public class GetSaldoContaCorrentePeloIdQueryHandler : IRequestHandler<GetSaldoContaCorrentePeloIdQuery, SaldoContaCorrente>
    {
        private readonly ISaldoContaCorrenteRepositorio _saldoContaCorrenteRepositorio;
        public GetSaldoContaCorrentePeloIdQueryHandler(ISaldoContaCorrenteRepositorio saldoContaCorrenteRepositorio)
        {
            _saldoContaCorrenteRepositorio = saldoContaCorrenteRepositorio;
        }

        public async Task<SaldoContaCorrente> Handle(GetSaldoContaCorrentePeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                return await _saldoContaCorrenteRepositorio.GetPeloIdAsync(request.Id);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
