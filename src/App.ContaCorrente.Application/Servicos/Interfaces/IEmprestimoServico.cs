using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IEmprestimoServico
    {
        Task<EmprestimoDTO> GetPeloIdAsync(int? id);

        Task<IEnumerable<EmprestimoDTO>> GetPeloCorrentistaIdAsync(int? id);

        Task<EmprestimoDTO> AlterarAsync(EmprestimoDTO emprestimoDto);

        Task<EmprestimoDTO> CriarAsync(EmprestimoDTO emprestimoDto);        

        decimal CalculaParcelaEmprestimo(decimal valor, int qtdParcelas, decimal juros);

        Task<EmprestimoEfetivarDTO> EfetivarEmprestimoAsync(int? id);

        Task<bool> AnaliseCreditoCorrentistaAsync(int? correntistaId, decimal valorEmprestimo);

        Task AtualizaSaldoDevedor(decimal valorParcela, Emprestimo emprestimo);
    }
}
