using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;

namespace App.ContaCorrente.Application.Servicos.Interfaces
{
    public interface IParcelasEmprestimoServico
    {
        Task<IEnumerable<ParcelasEmprestimoDTO>> GetPeloIdAsync(int? id);

        Task<IEnumerable<ParcelasEmprestimoDTO>> GetPeloEmprestimoIdAsync(int? id);

        Task<ParcelasEmprestimoDTO> AlterarAsync(ParcelasEmprestimoDTO parcelasEmprestimoDto);

        IEnumerable<ParcelasEmprestimoDTO> GerarParcelasEmprestimo(Emprestimo emprestimo);

        Task<IEnumerable<ParcelasEmprestimoDTO>> ProcessaPagamentoParcelasEmprestimoAsync();

        Task<ParcelasEmprestimoDTO> EfetivaPagamentoParcelaEmprestimoAsync(Emprestimo emprestimo, ParcelasEmprestimo parcela);

        Task<IEnumerable<ParcelasEmprestimoAntecipaDTO>> PagamentoAntecipadoParcelaEmprestimoAsync(IEnumerable<ParcelasEmprestimoAntecipaDTO> parcelasDto);


    }
}
