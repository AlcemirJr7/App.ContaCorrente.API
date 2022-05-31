namespace App.ContaCorrente.Domain.Entidades.Transferencia
{
    public interface ITransferenciaExterna
    {
        public int CodigoBanco { get; set; }

        public string CodigoAgencia { get; set; }

        public string NumeroConta { get; set; }

        public string NomePessoa { get; set; } 

        public string NumeroDocumento { get; set; }

    }
}
