using App.ContaCorrente.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IEmprestimoServico
    {
        Task<EmprestimoDTO> GetPeloIdAsync(int? id);

        Task<IEnumerable<EmprestimoDTO>> GetPeloCorrentistaIdAsync(int? id);

        Task<EmprestimoDTO> AlterarAsync(EmprestimoDTO emprestimoDto);

        Task<EmprestimoDTO> CriarAsync(EmprestimoDTO emprestimoDto);
    }
}
