using System.ComponentModel;

namespace App.ContaCorrente.Domain.Enumerador
{
    public enum EnumEmprestimoTipoFinalidade
    {
        PagarDividas = 1,
        Construir = 2,
        ComprarCarro = 3,
        Viajar = 4,
        DespesasMedicas = 5,
        Outros = 6

    }

    public enum EnumEmprestimoTipoEmprestimo
    {
        Financiamento = 1,
        EmprestimoPessoal = 2,
        EmprestimoChequeEspecial = 3

    }

    public enum EnumFlagEstadoEmprestimo
    {
        Proposta = 1,
        Efetivado = 2

    }

    public enum EnumProcessoEmprestimo
    {
        EmAnalise = 1,
        Rejeitado = 2,  
        Aprovado = 3

    }

    public enum EnumEmprestimoHistorico
    {
        [Description("Credito Contratação Empréstimo")]
        CreditoEmConta = 3

    }

}
