using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades
{
    public class ChavePix
    {
        public int Id { get; protected  set; }

        public string Chave { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public EnumChavePixTipo TipoChave { get; private set; }

        public EnumChavePixSituacao Situacao { get; private set; }

        public int CorrentistaId { get; set; }

        public Correntista correntista { get; set; }


        public ChavePix(string chave, DateTime dataCadastro, EnumChavePixTipo tipoChave, EnumChavePixSituacao situacao)
        {
            ValidarEntidade(chave, dataCadastro, tipoChave, situacao);
        }

        public ChavePix(string chave, DateTime dataCadastro, EnumChavePixTipo tipoChave, EnumChavePixSituacao situacao, int correntistaId)
        {
            ValidarEntidade(chave, dataCadastro, tipoChave, situacao);
            correntistaId = correntistaId;
        }

        public ChavePix(int id,string chave, DateTime dataCadastro, EnumChavePixTipo tipoChave, EnumChavePixSituacao situacao)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(chave, dataCadastro, tipoChave,situacao);
        }

        private void Atualizar(string chave, DateTime dataCadastro, EnumChavePixTipo tipoChave, EnumChavePixSituacao situacao, int correntistaId)
        {
            ValidarEntidade(chave, dataCadastro, tipoChave, situacao);
            CorrentistaId = correntistaId;
        }

        private void ValidarEntidade(string chave, DateTime dataCadastro, EnumChavePixTipo tipoChave, EnumChavePixSituacao situacao)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(chave), "Chave pix deve ser informada.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataCadastro)), "Data cadasto invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumChavePixTipo), tipoChave), "Tipo chave pix invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumChavePixSituacao), situacao), "Situação invalida.");

            switch (tipoChave)
            {
                case EnumChavePixTipo.Cpf:
                    DomainExcepitonValidacao.When(ValidadorDeCampos.ValidaCpf(StringFormata.ApenasNumeros(chave)), "Chave Cpf invalida.");
                    break;
                case EnumChavePixTipo.Cnpj:
                    DomainExcepitonValidacao.When(ValidadorDeCampos.ValidaCnpj(StringFormata.ApenasNumeros(chave)), "Chave Cnpj invalida.");
                    break;
                case EnumChavePixTipo.Email:
                    DomainExcepitonValidacao.When(ValidadorDeCampos.ValidaEmail(chave), "Chave Email invalida.");
                    break;
                case EnumChavePixTipo.Celular:
                    DomainExcepitonValidacao.When(ValidadorDeCampos.ValidaCelular(StringFormata.ApenasNumeros(chave)), "Chave Celular invalida.");
                    break;
                case EnumChavePixTipo.Aleatorio:                    
                    Chave = new Guid().ToString();                                        
                    break;
                default:
                    break;
            }

            if(tipoChave != EnumChavePixTipo.Email && tipoChave != EnumChavePixTipo.Aleatorio)
            {
                Chave = StringFormata.ApenasNumeros(chave);
            }

            DataCadastro = dataCadastro;
            TipoChave = tipoChave;
            Situacao = situacao;

        }

    }
}
