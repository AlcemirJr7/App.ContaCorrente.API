using App.ContaCorrente.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IEnderecoServico
    {
        Task<EnderecoDTO> GetPeloIdAsync(int? id);

        Task AlterarAsync(EnderecoDTO enderecoDto);

        Task CriarAsync(EnderecoDTO enderecoDto);

        Task DeletarAsync(int? id);
    }
}
