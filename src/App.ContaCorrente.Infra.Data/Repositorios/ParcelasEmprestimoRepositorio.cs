using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class ParcelasEmprestimoRepositorio : IParcelasEmprestimoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public ParcelasEmprestimoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<ParcelasEmprestimo> AlterarAsync(ParcelasEmprestimo parcelasEmprestimo)
        {
            try
            {
                _appDbContexto.Update(parcelasEmprestimo);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoAtualizarEntidade);
            }

            return parcelasEmprestimo;
        }

        public async Task<IEnumerable<ParcelasEmprestimo>> CriarAsync(IEnumerable<ParcelasEmprestimo> parcelasEmprestimo)
        {
            try
            {
                await _appDbContexto.AddRangeAsync(parcelasEmprestimo);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return parcelasEmprestimo;
            
        }

        public async Task<IEnumerable<ParcelasEmprestimo>> GetPeloEmprestimoIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.ParcelasEmprestimos.Where(e => e.EmprestimoId == id).ToListAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<ParcelasEmprestimo> GetSeqParcelaAsync(int? parcela, int? emprestimoId)
        {
            try
            {
                return await _appDbContexto.ParcelasEmprestimos.Where(p => p.SeqParcelas == parcela && p.EmprestimoId == emprestimoId).FirstOrDefaultAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<IEnumerable<ParcelasEmprestimo>> GetParcelasAhVencerAsync(int? emprestimoId)
        {
            try
            {
                var data = new DateTime(DateTime.Now.Year,DateTime.Now.Month,DateTime.Now.Day);

                return await _appDbContexto.ParcelasEmprestimos.Where(p => p.EmprestimoId == emprestimoId && 
                                                                           p.DataVencimento <= data &&
                                                                           p.DataPagamento == null).ToListAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
