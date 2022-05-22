using App.ContaCorrente.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IPessoaServico
    {
        Task<PessoaDTO> GetPeloIdAsync(int? id);

        Task AlterarAsync(PessoaDTO pessoaDto);


        Task CriarAsync(PessoaDTO pessoaDto);
    }
}
