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

        Task<EnderecoDTO> AlterarAsync(EnderecoDTO enderecoDto);

        Task CriarAsync(EnderecoDTO enderecoDto);

        Task<EnderecoDTO> DeletarAsync(int? id);
    }
}
