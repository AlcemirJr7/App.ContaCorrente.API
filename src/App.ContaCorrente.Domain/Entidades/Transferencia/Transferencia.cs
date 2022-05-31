using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades.Transferencia
{
    public class Transferencia : ITransferenciaInterna
    {
        public int Id { get; protected set; }
                       
        public DateTime? DataTransferencia { get; private set; }

        public DateTime DataCadatro { get; private set; }

        public decimal Valor { get; private set; }

        public EnumTransferenciaTipo TipoTransferencia { get; private set; }

        public EnumTransferenciaModo ModoTransferencia { get; private set; }

        public DateTime? DataAgendamento { get; private set; }        
        
        public string? ChavePixRecebe { get ; set ; }
        
        public string? ChavePixEnvia { get; set; }
               
        public string? NumeroContaRecebe { get ; set ; }
        
        public string? NumeroContaEnvia { get; set; }
        
        public int? CorrentistaRecebeId { get ; set; }
        
        public int? CorrentistaEnviaId { get ; set; }                       


        public Transferencia(DateTime? dataTransferencia, decimal valor, DateTime dataCadatro, EnumTransferenciaModo modoTransferencia, EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento)
        {
            ValidarEntidade(dataTransferencia, valor, dataCadatro, modoTransferencia, tipoTransferencia, dataAgendamento);
        }

        public Transferencia(int id, DateTime? dataTransferencia, decimal valor, DateTime dataCadatro, EnumTransferenciaModo modoTransferencia, EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(dataTransferencia, valor,dataCadatro, modoTransferencia, tipoTransferencia, dataAgendamento);
        }


        public Transferencia(DateTime? dataTransferencia, decimal valor, DateTime dataCadatro, EnumTransferenciaModo modoTransferencia, EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento, 
                             int? correntistaRecebeId, int? correntistaEnviaId, string? chavePixRecebe, string? chavePixEnvia, string? numeroContaRecebe, string? numeroContaEnvia)
        {
            ValidarEntidade(dataTransferencia, valor,dataCadatro, modoTransferencia, tipoTransferencia,dataAgendamento);            
            CorrentistaRecebeId = correntistaRecebeId;
            CorrentistaEnviaId = correntistaEnviaId;    
            ChavePixRecebe = chavePixRecebe;
            ChavePixEnvia = chavePixEnvia;
            NumeroContaRecebe = numeroContaRecebe;
            NumeroContaEnvia = numeroContaEnvia;

        }

        public void Atualizar(DateTime? dataTransferencia, decimal valor, DateTime dataCadatro, EnumTransferenciaModo modoTransferencia, EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento,
                             int? correntistaRecebeId, int? correntistaEnviaId, string? chavePixRecebe, string? chavePixEnvia, string? numeroContaRecebe, string? numeroContaEnvia)
        {
            ValidarEntidade(dataTransferencia, valor,dataCadatro, modoTransferencia, tipoTransferencia, dataAgendamento);            
            CorrentistaRecebeId = correntistaRecebeId;
            CorrentistaEnviaId = correntistaEnviaId;
            ChavePixRecebe = chavePixRecebe;
            ChavePixEnvia = chavePixEnvia;
            NumeroContaRecebe = numeroContaRecebe;
            NumeroContaEnvia = numeroContaEnvia;
        }
        
        private void ValidarEntidade(DateTime? dataTransferencia, decimal valor, DateTime dataCadatro, EnumTransferenciaModo modoTransferencia, EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento)
        {
            DomainExcepitonValidacao.When(valor <= 0, "Valor de transferencia invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumTransferenciaTipo), tipoTransferencia), "Tipo transferência invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumTransferenciaModo), modoTransferencia), "Modo transferência invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataCadatro)), "Data cadastro deve ser informado.");

            
            DataTransferencia = dataTransferencia;  
            Valor = valor;
            DataCadatro = dataCadatro;
            DataAgendamento = dataAgendamento;
            TipoTransferencia = tipoTransferencia;
            ModoTransferencia = modoTransferencia;


        }

    }
}
