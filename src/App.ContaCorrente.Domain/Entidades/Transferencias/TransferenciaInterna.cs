using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades.Transferencias
{
    public sealed class TransferenciaInterna : Transferencia
    {        
        public string? ChavePixRecebe { get; private set; }
        public string? ChavePixEnvia { get; private set; }
        public string? NumeroContaRecebe { get; private set; }
        public string? NumeroContaEnvia { get; private set; }
        public int CorrentistaRecebeId { get; private set; }
        public int CorrentistaEnviaId { get; private set; }

        public TransferenciaInterna(DateTime? dataTransferencia, decimal valor, DateTime dataCadatro, EnumTransferenciaModo modoTransferencia, 
                                   EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento, string? chavePixRecebe, string? chavePixEnvia, 
                                   string? numeroContaRecebe, string? numeroContaEnvia,int correntistaRecebeId, int correntistaEnviaId) 
                                   : base(dataTransferencia, valor, dataCadatro, modoTransferencia, tipoTransferencia, dataAgendamento)
        {            
            ValidarEntidade(chavePixRecebe, chavePixEnvia, numeroContaRecebe, numeroContaEnvia, correntistaRecebeId, correntistaEnviaId);
            
        }
        
        private void ValidarEntidade(string? chavePixRecebe, string? chavePixEnvia, string? numeroContaRecebe, string? numeroContaEnvia,
                                    int correntistaRecebeId, int correntistaEnviaId)
        {
            DomainExcepitonValidacao.When(correntistaRecebeId <= 0, "Id correntista recebe invalido.");
            DomainExcepitonValidacao.When(correntistaEnviaId <= 0, "Id correntista envia invalido.");

            ChavePixEnvia = chavePixEnvia;
            ChavePixRecebe = chavePixRecebe;
            NumeroContaEnvia = numeroContaEnvia;
            NumeroContaRecebe = numeroContaRecebe;
            CorrentistaEnviaId = correntistaEnviaId;
            CorrentistaRecebeId = correntistaRecebeId;
            
        }

        public void Atualizar(string? chavePixRecebe, string? chavePixEnvia, string? numeroContaRecebe, string? numeroContaEnvia,
                              int correntistaRecebeId, int correntistaEnviaId)
        {
            ValidarEntidade(chavePixRecebe, chavePixEnvia, numeroContaRecebe, numeroContaEnvia, correntistaRecebeId, correntistaEnviaId);

            ChavePixEnvia = chavePixEnvia;
            ChavePixRecebe = chavePixRecebe;
            NumeroContaEnvia = numeroContaEnvia;
            NumeroContaRecebe = numeroContaRecebe;
            CorrentistaEnviaId = correntistaEnviaId;
            CorrentistaRecebeId = correntistaRecebeId;
        }


        
    }
}
