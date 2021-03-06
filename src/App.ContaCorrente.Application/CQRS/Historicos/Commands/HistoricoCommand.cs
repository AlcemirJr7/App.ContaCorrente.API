using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using MediatR;


namespace App.ContaCorrente.Application.CQRS.Historicos.Commands
{
    public abstract class HistoricoCommand : IRequest<Historico>
    {
        
        public int Id { get; set; }
        
        public string Descricao { get; set; }

        /// <summary>
        /// 1 - Débito
        /// 2 - Crédito
        /// </summary>        
        public EnumHistoricoDebitoCredito TipoDebitoCredito { get; set; }
        
        public DateTime DataCriacao { get; set; }
    }
}
