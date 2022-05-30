using App.ContaCorrente.Domain.Enumerador;

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

        public static bool ValidaCelular(string valor)
        {
            
            string ddd = valor.Substring(0, 2);
            

            if (!Enum.IsDefined(typeof(EnumDDD), (EnumDDD)Convert.ToInt32(ddd)))
            {
                return false;
            }

            if(valor.Substring(2, 1) != "9")
            {
                return false;
            }

            if (valor.Length != 11)
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
