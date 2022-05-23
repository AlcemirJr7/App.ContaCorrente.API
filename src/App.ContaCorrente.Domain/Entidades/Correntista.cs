using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;


namespace App.ContaCorrente.Domain.Entidades
{
    public class Correntista 
    {
        public int Id { get; protected set; }

        public string? Agencia { get; private set; }

        public string? Conta { get; private set; }
        
        public DateTime? DataInicio { get; private set; }

        public DateTime? DataEncerramento { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public EnumContaCorrente FlagConta { get; private set; }

        public int PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }

        public int BancoId { get; set; }

        public Banco Banco { get; set; }

        public int? LocalTrabalhoId { get; set; }

        public LocalTrabalho LocalTrabalho { get; set; }


        public Correntista(string agencia, string conta,DateTime dataCadastro, DateTime? dataInicio, DateTime? dataEncerramento, EnumContaCorrente flagConta)
        {
            ValidarEntidade(agencia, conta, dataInicio, dataEncerramento, flagConta);
        }

        public Correntista(int id, string agencia, string conta, DateTime dataCadastro, DateTime? dataInicio, DateTime? dataEncerramento, EnumContaCorrente flagConta)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(agencia, conta, dataInicio, dataEncerramento, flagConta);
        }
        public Correntista(string agencia, string conta, DateTime dataCadastro, DateTime? dataInicio, DateTime? dataEncerramento, EnumContaCorrente flagConta, 
                           int pessoaId, int? localTrabalhoId)
        {
            DataCadastro = dataCadastro;
            ValidarEntidade(agencia, conta, dataInicio, dataEncerramento, flagConta);
            PessoaId = pessoaId;
            BancoId = 999;
            LocalTrabalhoId = localTrabalhoId;
            
        }

        public void Atualizar(string agencia, string conta, DateTime? dataInicio, DateTime? dataEncerramento, EnumContaCorrente flagConta, int pessoaId)
        {
            ValidarEntidade(agencia, conta, dataInicio, dataEncerramento, flagConta);
            PessoaId = pessoaId;            
        }

        private void ValidarEntidade(string agencia, string conta, DateTime? dataInicio, DateTime? dataEncerramento, EnumContaCorrente flagConta)
        {


            //DomainExcepitonValidacao.When(string.IsNullOrEmpty(StringFormata.ApenasNumeros(agencia)), "Agencia deve ser informada.");
            //DomainExcepitonValidacao.When(string.IsNullOrEmpty(StringFormata.ApenasNumeros(conta)), "Conta deve ser informada.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumContaCorrente), flagConta), "Flag Conta corrente invalido.");
            //DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataInicio)), "Data de Inicio deve ser informado.");            
                        
            Agencia = "0001";
            Conta = GeradorConta.GeraNumeroConta(DataCadastro);
            DataInicio = dataInicio;
            DataEncerramento = dataEncerramento;
            FlagConta = flagConta;
            
        }

    }
}
