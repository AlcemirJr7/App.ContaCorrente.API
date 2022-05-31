namespace App.ContaCorrente.Domain.Entidades.Transferencia
{
    public abstract class TransferenciaExterna : ITransferenciaExterna
    {
        public abstract int CodigoBanco { get; set; }
        public abstract string CodigoAgencia { get; set; }
        public abstract string NumeroConta { get; set; }
        public abstract string NomePessoa { get; set; }
        public abstract string NumeroDocumento { get; set; }
    }
}
