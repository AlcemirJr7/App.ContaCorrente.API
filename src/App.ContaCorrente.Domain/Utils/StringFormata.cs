
namespace App.ContaCorrente.Domain.Utils
{
    public static class StringFormata
    {
        public static string ApenasNumeros(string? valor)
        {
            return string.Join("", valor.ToCharArray().Where(Char.IsDigit));
        }  
        
    }
}
