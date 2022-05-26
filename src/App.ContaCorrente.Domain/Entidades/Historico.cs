using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Historico
    {
        public int Id { get; protected set; }

        public string Descricao { get; private set; }

        public EnumHistoricoDebitoCredito TipoDebitoCredito { get; private set; }

        public DateTime DataCriacao { get; set; }


        public Historico(string descricao, EnumHistoricoDebitoCredito tipoDebitoCredito)
        {
            ValidarEntidade(descricao,tipoDebitoCredito);
        }

        public Historico(int id,string descricao, EnumHistoricoDebitoCredito tipoDebitoCredito)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;            
            ValidarEntidade(descricao,tipoDebitoCredito);
        }

        public void Atualizar(string descricao, EnumHistoricoDebitoCredito tipoDebitoCredito)
        {
            ValidarEntidade(descricao,tipoDebitoCredito);
        }

        private void ValidarEntidade(string descricao, EnumHistoricoDebitoCredito tipoDebitoCredito)
        {
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(descricao), "Descrição do histórico deve ser informado.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumHistoricoDebitoCredito), tipoDebitoCredito), "Tipo debito credito invalido.");

            Descricao = descricao;            
            TipoDebitoCredito = tipoDebitoCredito;
        }
    }
}
