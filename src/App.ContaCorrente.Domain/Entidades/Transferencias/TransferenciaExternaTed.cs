using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades.Transferencias
{
    public sealed class TransferenciaExternaTed : Transferencia
    {
        public int? CorrentistaEnviaId { get; private set; }
        public int? CodigoBancoExterno { get; private set; }
        public string? CodigoAgenciaEterno { get; private set; }
        public string? NumeroContaExtero { get; private set; }
        public string? NomePessoaExtero { get; private set; }
        public string? NumeroDocumentoExterno { get; private set; }


        public TransferenciaExternaTed(DateTime? dataTransferencia, decimal valor, DateTime dataCadatro, EnumTransferenciaModo modoTransferencia, 
                                       EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento, int? correntistaEnviaId, int? codigoBancoExterno, 
                                       string? codigoAgenciaEterno, string? numeroContaExtero,
                                       string? nomePessoaExtero, string? numeroDocumentoExterno) 
                                       : base(dataTransferencia, valor, dataCadatro, modoTransferencia, tipoTransferencia, dataAgendamento)
        {
            ValidarEntidade(correntistaEnviaId, codigoBancoExterno, codigoAgenciaEterno, numeroContaExtero, nomePessoaExtero, numeroDocumentoExterno);
        }

        private void ValidarEntidade(int? correntistaEnviaId, int? codigoBancoExterno, string? codigoAgenciaEterno, string? numeroContaExtero, 
                                     string? nomePessoaExtero,string? numeroDocumentoExterno)
        {
            DomainExcepitonValidacao.When(correntistaEnviaId <= 0, "Id do correntista invalido.");
            DomainExcepitonValidacao.When(codigoBancoExterno <= 0, "Código do banco invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(codigoAgenciaEterno), "Código da agência invalida.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(numeroContaExtero), "Número da conta invalida.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(nomePessoaExtero), "Nome da pessoa invalida.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(numeroDocumentoExterno), "Numero documento invalido.");

            if (numeroDocumentoExterno?.Length > 11)
            {
                DomainExcepitonValidacao.When(!ValidadorDeCampos.ValidaCnpj(StringFormata.ApenasNumeros(numeroDocumentoExterno)), "Numero documento invalido.");
            }
            else
            {
                DomainExcepitonValidacao.When(!ValidadorDeCampos.ValidaCpf(StringFormata.ApenasNumeros(numeroDocumentoExterno)), "Numero documento invalido.");
            }

            CorrentistaEnviaId = correntistaEnviaId;
            CodigoBancoExterno = codigoBancoExterno;
            CodigoAgenciaEterno = codigoAgenciaEterno;
            NumeroDocumentoExterno = numeroDocumentoExterno;
            NomePessoaExtero = nomePessoaExtero;
            NumeroDocumentoExterno = numeroDocumentoExterno;
            NumeroContaExtero = numeroContaExtero;  
        }

        public void Atualizar(int? correntistaEnviaId, int? codigoBancoExterno, string? codigoAgenciaEterno, string? numeroContaExtero,
                              string? nomePessoaExtero, string? numeroDocumentoExterno)
        {
            ValidarEntidade(correntistaEnviaId, codigoBancoExterno, codigoAgenciaEterno, numeroContaExtero, nomePessoaExtero, numeroDocumentoExterno);
        }
    }
}
