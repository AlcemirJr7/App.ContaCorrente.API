using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Enumerador
{
    public enum EnumContaCorrente
    {
        EmAnalise = 1,
        Aberta = 2,
        Fechada = 3
    }

    public enum EnumAgencia
    {        
        [Description("0001")]
        Agencia = 1
    }

    public enum EnumBanco
    {        
        Banco = 999
    }
}
