using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Utils
{
    public static class ValidadorDeCampos
    {
        public static bool ValidaCpf(string valor)
        {
            if (valor.Length != 11)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidaCnpj(string valor)
        {
            if (valor.Length != 14)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool ValidaEmail(string valor)
        {
            if (!valor.Contains("@") || !valor.Contains("."))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
       
    }
}
