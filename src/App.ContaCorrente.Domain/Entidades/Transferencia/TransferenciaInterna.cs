using App.ContaCorrente.Domain.Entidades.Transferencia;

namespace App.ContaCorrente.Domain.Entidades
{
    public abstract class TransferenciaInterna : ITransferenciaInterna
    {
        public abstract string? ChavePixRecebe { get; set; }
        public abstract string? ChavePixEnvia { get; set; }
        public abstract string? NumeroContaRecebe { get; set; }
        public abstract string? NumeroContaEnvia { get; set; }
        public abstract int? CorrentistaRecebeId { get; set; }
        public abstract int? CorrentistaEnviaId { get; set; }
        
    }
}
