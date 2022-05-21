using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Domain.Enumerador
{
    public enum EnumPessoa
    {
        [Display(Name = "Pessoa Fisica")]
        PessoaFisica = 1,
        [Display(Name = "Pessoa Juridica")]
        PessoaJuridica = 2

    }
}
