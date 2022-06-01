using System.ComponentModel;

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
        [AmbientValue("0001")]
        Agencia = 1
    }

    public enum EnumBanco
    {        
        Banco = 999
    }


}
