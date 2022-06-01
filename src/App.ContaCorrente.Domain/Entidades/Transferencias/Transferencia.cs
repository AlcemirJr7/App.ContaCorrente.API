using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades.Transferencias
{
    public class Transferencia
    {
        public int Id { get; protected set; }
                       
        public DateTime? DataTransferencia { get; protected set; }

        public DateTime DataCadatro { get; protected set; }

        public decimal Valor { get; protected set; }

        public EnumTransferenciaTipo TipoTransferencia { get; protected set; }

        public EnumTransferenciaModo ModoTransferencia { get; protected set; }

        public DateTime? DataAgendamento { get; protected set; }


        public Transferencia()
        {

        }

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

        
        public void Atualizar(DateTime? dataTransferencia, decimal valor, DateTime dataCadatro, EnumTransferenciaModo modoTransferencia, 
                              EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento)
        {
            ValidarEntidade(dataTransferencia, valor,dataCadatro, modoTransferencia, tipoTransferencia, dataAgendamento);                        
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
