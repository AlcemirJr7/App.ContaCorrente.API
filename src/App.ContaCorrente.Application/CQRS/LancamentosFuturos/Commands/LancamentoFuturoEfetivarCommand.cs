using App.ContaCorrente.Domain.Entidades;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.LancamentosFuturos.Commands
{
    public class LancamentoFuturoEfetivarCommand : IRequest<IEnumerable<LancamentoFuturo>>
    {
        public LancamentoFuturoEfetivarCommand()
        {

        }
    }
}
