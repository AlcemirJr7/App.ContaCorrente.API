using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Utils;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Correntista : LoginCorrentista
    {
        public int Id { get; protected set; }

        public string Agencia { get; private set; }

        public string Conta { get; private set; }
        
        public DateTime DataInicio { get; private set; }

        public DateTime? DataEncerramento { get; private set; }

        public EnumContaCorrente FlagConta { get; private set; }

        public int PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }

        public int BancoId { get; set; }

        public Banco Banco { get; set; }

        public int? LocalTrabalhoId { get; set; }

        public LocalTrabalho LocalTrabalho { get; set; }


        public Correntista(string agencia, string conta, DateTime dataInicio, DateTime? dataEncerramento, EnumContaCorrente flagConta, string senha, string senhaConfirmacao )
        {
            ValidarEntidade(agencia, conta, dataInicio, dataEncerramento, flagConta, senha, senhaConfirmacao);
        }

        public Correntista(int id, string agencia, string conta, DateTime dataInicio, DateTime? dataEncerramento, EnumContaCorrente flagConta, string senha, string senhaConfirmacao)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(agencia, conta, dataInicio, dataEncerramento, flagConta, senha, senhaConfirmacao);
        }
        public Correntista(string agencia, string conta, DateTime dataInicio, DateTime? dataEncerramento, EnumContaCorrente flagConta, string senha, string senhaConfirmacao , 
                           int pessoaId, int bancoId, int? localTrabalhoId)
        {
            ValidarEntidade(agencia, conta, dataInicio, dataEncerramento, flagConta, senha, senhaConfirmacao);
            PessoaId = pessoaId;
            BancoId = bancoId;
            LocalTrabalhoId = localTrabalhoId;
        }

        public void Atualizar(string agencia, string conta, DateTime dataInicio, DateTime? dataEncerramento, EnumContaCorrente flagConta, string senha, string senhaConfirmacao, int pessoaId, int bancoId)
        {
            ValidarEntidade(agencia, conta, dataInicio, dataEncerramento, flagConta, senha, senhaConfirmacao);
            PessoaId = pessoaId;
            BancoId = bancoId;
        }

        private void ValidarEntidade(string agencia, string conta, DateTime dataInicio, DateTime? dataEncerramento, EnumContaCorrente flagConta, string senha, string senhaConfirmacao)
        {


            DomainExcepitonValidacao.When(string.IsNullOrEmpty(StringFormata.ApenasNumeros(agencia)), "Agencia deve ser informada.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(StringFormata.ApenasNumeros(conta)), "Conta deve ser informada.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumContaCorrente), flagConta), "Flag Conta corrente invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataInicio)), "Data de Inicio deve ser informado.");
            DomainExcepitonValidacao.When(senha != senhaConfirmacao, "Senha e Senha Confimarção são diferentes.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(senha), "Senha não pode ser vazio.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(senhaConfirmacao), "Senha confirmação não pode ser vazio.");

            
            Senha = CriaHash(senha);
            SenhaConfirmacao = CriaHash(senhaConfirmacao);
            Agencia = agencia;
            Conta = conta;
            DataInicio = dataInicio;
            DataEncerramento = dataEncerramento;
            FlagConta = flagConta;
            
        }

    }
}
