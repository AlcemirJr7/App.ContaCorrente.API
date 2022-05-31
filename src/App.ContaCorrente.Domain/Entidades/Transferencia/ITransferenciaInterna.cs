namespace App.ContaCorrente.Domain.Entidades.Transferencia
{
    public interface ITransferenciaInterna
    {
        public string? ChavePixRecebe { get; set; }

        public string? ChavePixEnvia { get; set; }        

        public string? NumeroContaRecebe { get; set; }

        public string? NumeroContaEnvia { get; set; }

        public int? CorrentistaRecebeId { get; set; }

        public int? CorrentistaEnviaId { get; set; }
        
    }
}
