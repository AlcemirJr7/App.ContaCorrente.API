using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades
{
    public class LancamentoFuturo
    {
        public int Id { get; protected set; }

        public decimal Valor { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public DateTime DataParaLancamento { get; private set; }

        public EnumLancamentoFuturo FlagLancamento { get; private set; }

        public DateTime? DataLancamento { get; private set; }
        
        public EnumTipoLancamentoFuturo TipoLancamento { get; private set; }

        public string? Observacao { get; private set; }

        public int HistoricoId { get; set; }

        public Historico Historico { get; set; }

        public int CorrentistaId { get; set; }

        public Correntista Correntista { get; set; }

        public LancamentoFuturo(decimal valor,DateTime dataCadastro,DateTime dataParaLancamento, EnumTipoLancamentoFuturo tipoLancamento, EnumLancamentoFuturo flagLancamento, 
                                DateTime? dataLancamento, string? observacao)
        {
            ValidarEntidade(valor, dataCadastro, dataParaLancamento, tipoLancamento ,flagLancamento, dataLancamento, observacao);
        }

        public LancamentoFuturo(int id,decimal valor, DateTime dataCadastro, DateTime dataParaLancamento, EnumTipoLancamentoFuturo tipoLancamento, EnumLancamentoFuturo flagLancamento, 
                                DateTime? dataLancamento, string? observacao)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(valor, dataCadastro, dataParaLancamento, tipoLancamento ,flagLancamento, dataLancamento, observacao);
        }

        public LancamentoFuturo(decimal valor, DateTime dataCadastro, DateTime dataParaLancamento, EnumTipoLancamentoFuturo tipoLancamento, EnumLancamentoFuturo flagLancamento, DateTime? dataLancamento,
                                string? observacao, int historicoId, int correntistaId)
        {
            ValidarEntidade(valor, dataCadastro, dataParaLancamento, tipoLancamento ,flagLancamento, dataLancamento, observacao);
            HistoricoId = historicoId;
            CorrentistaId = correntistaId;
        }

        public void Atualizar(decimal valor, DateTime dataCadastro, DateTime dataParaLancamento, EnumTipoLancamentoFuturo tipoLancamento, EnumLancamentoFuturo flagLancamento, DateTime? dataLancamento,
                             string? observacao, int historicoId, int correntistaId)
        {
            ValidarEntidade(valor, dataCadastro, dataParaLancamento, tipoLancamento ,flagLancamento, dataLancamento, observacao);
            HistoricoId = historicoId;
            CorrentistaId = correntistaId;
        }

        private void ValidarEntidade(decimal valor, DateTime dataCadastro, DateTime dataParaLancamento, EnumTipoLancamentoFuturo tipoLancamento, EnumLancamentoFuturo flagLancamento, 
                                     DateTime? dataLancamento, string? observacao)
        {
            DomainExcepitonValidacao.When(valor <= 0, "Valor invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataCadastro)), "Data Cadastro invalido.");
            DomainExcepitonValidacao.When(string.IsNullOrEmpty(Convert.ToString(dataParaLancamento)), "Data para lançamento invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumLancamentoFuturo),flagLancamento), "Flag lançamento invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumTipoLancamentoFuturo), tipoLancamento), "Tipo lançamento invalido.");

            Valor = valor;
            DataCadastro = dataCadastro;
            DataParaLancamento = dataParaLancamento;
            FlagLancamento = flagLancamento;
            DataLancamento = dataLancamento;
            TipoLancamento = tipoLancamento;
            Observacao = observacao;
        }
    }
}
