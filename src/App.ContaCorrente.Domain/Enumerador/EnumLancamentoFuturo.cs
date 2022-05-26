namespace App.ContaCorrente.Domain.Enumerador
{
    public enum EnumLancamentoFuturo
    {
        Pendente = 1,
        Efetuado = 2
    }

    public enum EnumTipoLancamentoFuturo
    {
        Pagamento = 1,
        Emprestimo = 2,
        ParcelaEmprestimo = 3,
        Transferencia = 4,
        Outros = 5 

    }
}
