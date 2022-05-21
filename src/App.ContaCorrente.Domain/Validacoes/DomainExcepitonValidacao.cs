using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Validacoes
{
    
    public class DomainExcepitonValidacao : Exception
    {
        public DomainExcepitonValidacao(string error) : base(error)
        { }

        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExcepitonValidacao(error);
        }
    }
    
}
