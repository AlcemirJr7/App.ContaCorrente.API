using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Enumerador
{
    //(1 - Pagardividas, 2 - construir, 3 - comprar carro, 4 - viajar, 5 - Despesas Médicas, 6 - Outros)
    //(1 - Financiamento, 2 - EmprestimoPessoal)


    public enum EnumEmprestimoTipoFinalidade
    {
        Pagardividas = 1,
        construir = 2,
        comprarcarro = 3,
        Viajar = 4,
        DespesasMedicas = 5,
        Outros = 6


    }

    public enum EnumEmprestimoTipoEmprestimo
    {
        Financiamento = 1,
        EmprestimoPessoal = 2

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

}
