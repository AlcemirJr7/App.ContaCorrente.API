using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Transferencia
    {
        public int Id { get; protected set; }
        
        public string? NumeroConta { get; private set; }

        public string? Agencia { get; private set; }

        public string? NumeroDocumento { get; private set; }

        public string? NomePessoa { get; private set; }
        
        public DateTime? DataTransferencia { get; private set; }

        public DateTime DataCadatro { get; private set; }

        public decimal Valor { get; private set; }

        public EnumTransferenciaTipo TipoTransferencia { get; private set; }

        public DateTime? DataAgendamento { get; private set; }

        public int? ChavePixId { get; private set; }
        
        public ChavePix? ChavePix { get; set; }

        public int? BancoId { get; set; }

        public Banco? Banco { get; set; }

        public int? CorrentistaRecebeId { get; set; }

        public Correntista? CorrentistaRecebe { get; set; }

        public int? CorrentistaEnviaId { get; set; }

        public Correntista? CorrentistaEnvia { get; set; }

        public Transferencia(string? numeroConta, string? agencia, DateTime? dataTransferencia, decimal valor, string? numeroDocumento, string? nomePessoa, DateTime dataCadatro, EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento)
        {
            ValidarEntidade(numeroConta, agencia, dataTransferencia, valor, numeroDocumento, nomePessoa, dataCadatro, tipoTransferencia, dataAgendamento);
        }

        public Transferencia(int id, string? numeroConta, string? agencia, DateTime? dataTransferencia, decimal valor, string? numeroDocumento, string? nomePessoa, DateTime dataCadatro, EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(numeroConta, agencia, dataTransferencia, valor, numeroDocumento, nomePessoa, dataCadatro, tipoTransferencia, dataAgendamento);
        }


        public Transferencia(string? numeroConta, string? agencia, DateTime? dataTransferencia, decimal valor, string? numeroDocumento, string? nomePessoa, DateTime dataCadatro, EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento, 
                             int? bancoId, int? correntistaRecebeId, int? correntistaEnviaId, int? chavePixId)
        {
            ValidarEntidade(numeroConta, agencia, dataTransferencia, valor,numeroDocumento,nomePessoa,dataCadatro,tipoTransferencia,dataAgendamento);
            BancoId = bancoId;
            CorrentistaRecebeId = correntistaRecebeId;
            CorrentistaEnviaId = correntistaEnviaId;    
            ChavePixId = chavePixId;    
        }

        public void Atualizar(string? numeroConta, string? agencia, DateTime? dataTransferencia, decimal valor, string? numeroDocumento, string? nomePessoa, DateTime dataCadatro, EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento,
                             int? bancoId, int? correntistaRecebeId, int? correntistaEnviaId, int? chavePixId)
        {
            ValidarEntidade(numeroConta, agencia, dataTransferencia, valor, numeroDocumento, nomePessoa, dataCadatro, tipoTransferencia, dataAgendamento);
            BancoId = bancoId;
            CorrentistaRecebeId = correntistaRecebeId;
            CorrentistaEnviaId = correntistaEnviaId;
            ChavePixId = chavePixId;
        }
        
        private void ValidarEntidade(string? numeroConta, string? agencia, DateTime? dataTransferencia, decimal valor, string? numeroDocumento, string? nomePessoa, DateTime dataCadatro, EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento)
        {
            DomainExcepitonValidacao.When(valor <= 0, "Valor de transferencia invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumTransferenciaTipo), tipoTransferencia), "Tipo transferência invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataCadatro)), "Data cadastro deve ser informado.");


            NumeroConta = StringFormata.ApenasNumeros(numeroConta);
            Agencia = StringFormata.ApenasNumeros(agencia);
            DataTransferencia = dataTransferencia;  
            Valor = valor;
            DataCadatro = dataCadatro;
            DataAgendamento = dataAgendamento;
            TipoTransferencia = tipoTransferencia;
            NomePessoa = nomePessoa;
            NumeroDocumento = numeroDocumento;


        }

    }
}
