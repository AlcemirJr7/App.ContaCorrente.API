using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades.Transferencias
{
    public sealed class TransferenciaExternaPix : Transferencia
    {
        public TransferenciaExternaPix(DateTime? dataTransferencia, decimal valor, DateTime dataCadatro, EnumTransferenciaModo modoTransferencia,
                                       EnumTransferenciaTipo tipoTransferencia, DateTime? dataAgendamento, string? chavePixRecebe, string? chavePixEnvia,
                                       string? chavePixRecebeExterno, string? chavePixEnviaExterno, int? correntistaRecebeId, int? correntistaEnviaId, 
                                       EnumChavePixTipo tipoChave)
                                    : base(dataTransferencia, valor, dataCadatro, modoTransferencia, tipoTransferencia, dataAgendamento)
        {
            ValidarEntidade(chavePixRecebe, chavePixEnvia, chavePixRecebeExterno, chavePixEnviaExterno, correntistaRecebeId, correntistaEnviaId, tipoChave);

        }

        public EnumChavePixTipo TipoChave { get; private set; }
        public string? ChavePixRecebeExterno { get; private set; }
        public string? ChavePixEnviaExterno { get; private set; }
        public string? ChavePixRecebe { get; private set; }
        public string? ChavePixEnvia { get; private set; }
        public int? CorrentistaRecebeId { get; private set; }
        public int? CorrentistaEnviaId { get; private set; }

        private void ValidarEntidade(string? chavePixRecebe, string? chavePixEnvia, string? chavePixRecebeExterno, string? chavePixEnviaExterno,
                                    int? correntistaRecebeId, int? correntistaEnviaId, EnumChavePixTipo tipoChave)
        {
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumChavePixTipo), tipoChave), "Tipo chave pix invalido.");

            switch (tipoChave)  
            {
                case EnumChavePixTipo.Cpf:
                    {
                        if(chavePixRecebeExterno != null)
                        {
                            DomainExcepitonValidacao.When(!ValidadorDeCampos.ValidaCpf(StringFormata.ApenasNumeros(chavePixRecebeExterno)), "Chave cpf recebe externo invalido.");
                        }

                        if(chavePixEnviaExterno != null)
                        {
                            DomainExcepitonValidacao.When(!ValidadorDeCampos.ValidaCpf(StringFormata.ApenasNumeros(chavePixEnviaExterno)), "Chave cpf envia externo invalido.");
                        }
                        
                        ChavePixEnviaExterno = chavePixEnviaExterno;
                        ChavePixRecebeExterno = chavePixRecebeExterno;
                    }                    
                    break;
                case EnumChavePixTipo.Cnpj:
                    {
                        if (chavePixRecebeExterno != null)
                        {
                            DomainExcepitonValidacao.When(!ValidadorDeCampos.ValidaCpf(StringFormata.ApenasNumeros(chavePixRecebeExterno)), "Chave cnpj recebe externo invalido.");
                        }

                        if (chavePixEnviaExterno != null)
                        {
                            DomainExcepitonValidacao.When(!ValidadorDeCampos.ValidaCpf(StringFormata.ApenasNumeros(chavePixEnviaExterno)), "Chave cnpj envia externo invalido.");
                        }
                        
                        ChavePixEnviaExterno = chavePixEnviaExterno;
                        ChavePixRecebeExterno = chavePixRecebeExterno;
                    }
                    break;
                case EnumChavePixTipo.Email:
                    {
                        if (chavePixRecebeExterno != null)
                        {
                            DomainExcepitonValidacao.When(!ValidadorDeCampos.ValidaEmail(chavePixRecebeExterno), "Chave email recebe externo invalido.");
                        }

                        if (chavePixEnviaExterno != null)
                        {
                            DomainExcepitonValidacao.When(!ValidadorDeCampos.ValidaEmail(chavePixEnviaExterno), "Chave email envia externo invalido.");
                        }                                                
                        ChavePixEnviaExterno = chavePixEnviaExterno;
                        ChavePixRecebeExterno = chavePixRecebeExterno;
                    }
                    break;
                case EnumChavePixTipo.Celular:
                    {
                        if (chavePixRecebeExterno != null)
                        {
                            DomainExcepitonValidacao.When(!ValidadorDeCampos.ValidaCelular(StringFormata.ApenasNumeros(chavePixRecebeExterno)), "Chave celular recebe externo invalido.");
                        }

                        if (chavePixEnviaExterno != null)
                        {
                            DomainExcepitonValidacao.When(!ValidadorDeCampos.ValidaCelular(StringFormata.ApenasNumeros(chavePixEnviaExterno)), "Chave celular envia externo invalido.");
                        }                                                
                        ChavePixEnviaExterno = chavePixEnviaExterno;
                        ChavePixRecebeExterno = chavePixRecebeExterno;
                    }
                    break;
                case EnumChavePixTipo.Aleatorio:
                    {
                        if(ChavePixEnviaExterno == null && ChavePixRecebeExterno == null)
                        {
                            DomainExcepitonValidacao.When(true,"Chave aleatória deve ser informada.");
                        }
                        ChavePixEnviaExterno = chavePixEnviaExterno;
                        ChavePixRecebeExterno = chavePixRecebeExterno;
                    }
                    break;
                default:
                    break;
            }

            ChavePixEnvia = chavePixEnvia;
            ChavePixRecebe = chavePixRecebe;            
            CorrentistaRecebeId = correntistaRecebeId;
            CorrentistaEnviaId = correntistaEnviaId; 
            TipoChave = tipoChave;
        }

        public void Atualizar(string? chavePixRecebe, string? chavePixEnvia, string? chavePixRecebeExterno, string? chavePixEnviaExterno,
                              int? correntistaRecebeId, int? correntistaEnviaId, EnumChavePixTipo tipoChave)
        {
            ValidarEntidade(chavePixRecebe, chavePixEnvia, chavePixRecebeExterno, chavePixEnviaExterno, correntistaRecebeId, correntistaEnviaId, tipoChave);
        }
    }
}
