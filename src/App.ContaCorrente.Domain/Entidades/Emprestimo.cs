using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Validacoes;

namespace App.ContaCorrente.Domain.Entidades
{
    public class Emprestimo
    {
        public int Id { get; protected set; }

        public decimal Valor { get; private set; }

        public EnumEmprestimoTipoFinalidade TipoFinalidade { get; private set; }

        public EnumEmprestimoTipoEmprestimo TipoEmprestimo { get; private set; }

        public int QtdParcelas { get; private set; }

        public decimal ValorParcela { get; private set; }

        public decimal Juros { get; private set; }

        public DateTime DataCadastro { get; private set; }

        public DateTime? DataEfetivacao { get; private set; }

        public EnumFlagEstadoEmprestimo FlagEstado { get; private set; }

        public EnumProcessoEmprestimo FlagProcesso { get; private set; }

        public int CorrentistaId { get; set; }

        public Correntista Correntista { get; set; }

        public Emprestimo(decimal valor, EnumEmprestimoTipoFinalidade tipoFinalidade, EnumEmprestimoTipoEmprestimo tipoEmprestimo, int qtdParcelas, decimal valorParcela, 
                          decimal juros,DateTime? dataEfetivacao, EnumFlagEstadoEmprestimo flagEstado, EnumProcessoEmprestimo flagProcesso)
        {
            ValidarEntidade(valor, tipoFinalidade, tipoEmprestimo, qtdParcelas, valorParcela, juros, dataEfetivacao, flagEstado, flagProcesso);            
        }

        public Emprestimo(int id,decimal valor, EnumEmprestimoTipoFinalidade tipoFinalidade, EnumEmprestimoTipoEmprestimo tipoEmprestimo, int qtdParcelas, decimal valorParcela,
                          decimal juros, DateTime? dataEfetivacao, EnumFlagEstadoEmprestimo flagEstado, EnumProcessoEmprestimo flagProcesso)
        {
            DomainExcepitonValidacao.When(id < 0, "Id invalido.");
            Id = id;
            ValidarEntidade(valor, tipoFinalidade, tipoEmprestimo, qtdParcelas, valorParcela, juros, dataEfetivacao, flagEstado, flagProcesso);
        }
        public Emprestimo(decimal valor, EnumEmprestimoTipoFinalidade tipoFinalidade, EnumEmprestimoTipoEmprestimo tipoEmprestimo, int qtdParcelas, decimal valorParcela,
                          decimal juros, DateTime? dataEfetivacao, DateTime dataCadastro, EnumFlagEstadoEmprestimo flagEstado, EnumProcessoEmprestimo flagProcesso, int correntistaId)
        {
            ValidarEntidade(valor, tipoFinalidade, tipoEmprestimo, qtdParcelas, valorParcela, juros, dataEfetivacao,  flagEstado, flagProcesso);
            DataCadastro = dataCadastro;
            CorrentistaId = correntistaId;
        }

        public void Atualizar(decimal valor, EnumEmprestimoTipoFinalidade tipoFinalidade, EnumEmprestimoTipoEmprestimo tipoEmprestimo, int qtdParcelas, decimal valorParcela,
                              decimal juros, DateTime? dataEfetivacao, EnumFlagEstadoEmprestimo flagEstado, 
                              EnumProcessoEmprestimo flagProcesso, int correntistaId)
        {
            
            DomainExcepitonValidacao.When(flagEstado == EnumFlagEstadoEmprestimo.Efetivado, "Emrepstimo efetivado não pode ser alterado.");
            
            ValidarEntidade(valor, tipoFinalidade, tipoEmprestimo, qtdParcelas, valorParcela, juros, dataEfetivacao, flagEstado, flagProcesso);
            CorrentistaId = correntistaId;

        }

        public void AtualizarEfetivacao(decimal valor, EnumEmprestimoTipoFinalidade tipoFinalidade, EnumEmprestimoTipoEmprestimo tipoEmprestimo, int qtdParcelas, decimal valorParcela,
                                        decimal juros, DateTime? dataEfetivacao, EnumFlagEstadoEmprestimo flagEstado, EnumProcessoEmprestimo flagProcesso, int correntistaId)
        {
            DomainExcepitonValidacao.When(FlagEstado == EnumFlagEstadoEmprestimo.Efetivado, "Emrepstimo já efetivado.");

            ValidarEntidade(valor, tipoFinalidade, tipoEmprestimo, qtdParcelas, valorParcela, juros, dataEfetivacao, flagEstado, flagProcesso);
            CorrentistaId = correntistaId;

        }

        private void ValidarEntidade(decimal valor, EnumEmprestimoTipoFinalidade tipoFinalidade, EnumEmprestimoTipoEmprestimo tipoEmprestimo, int qtdParcelas, decimal valorParcela,
                                     decimal juros, DateTime? dataEfetivacao, EnumFlagEstadoEmprestimo flagEstado, EnumProcessoEmprestimo flagProcesso)
        {
            DomainExcepitonValidacao.When(valor <= 0, "Valor Emprestimo invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumEmprestimoTipoFinalidade), tipoFinalidade), "Tipo finalidade Emprestimo invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumEmprestimoTipoEmprestimo), tipoEmprestimo), "Tipo Emprestimo invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumFlagEstadoEmprestimo), flagEstado), "Flag estado Emprestimo invalido.");
            DomainExcepitonValidacao.When(!Enum.IsDefined(typeof(EnumProcessoEmprestimo), flagProcesso), "Flag processo Emprestimo invalido.");
            DomainExcepitonValidacao.When(juros <= 0, "Juros Emprestimo invalido.");
            DomainExcepitonValidacao.When(qtdParcelas <= 0, "Quantidade de parcelas Emprestimo invalido.");
            DomainExcepitonValidacao.When(valorParcela < 0, "Valor parcela Emprestimo invalido.");

            Valor = valor;
            TipoFinalidade = tipoFinalidade;    
            TipoEmprestimo = tipoEmprestimo;
            QtdParcelas = qtdParcelas;  
            ValorParcela = valorParcela;
            Juros = juros;
            DataEfetivacao = dataEfetivacao;
            FlagEstado = flagEstado;
            FlagProcesso = flagProcesso;            
        }
    }
}
