using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class LancamentoFuturoRepositorio : ILancamentoFuturoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public LancamentoFuturoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<LancamentoFuturo> AlterarAsync(LancamentoFuturo lancamentoFuturo)
        {
            try
            {
                _appDbContexto.Update(lancamentoFuturo);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoAlterarEntidade);
            }

            return lancamentoFuturo;
        }

        public async Task<LancamentoFuturo> CriarAsync(LancamentoFuturo lancamentoFuturo)
        {
            try
            {
                _appDbContexto.Add(lancamentoFuturo);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return lancamentoFuturo;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<LancamentoFuturo>> GetPeloCorrentistaIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.LancamentosFuturos.Where(l => l.CorrentistaId == id).ToListAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<LancamentoFuturo> GetPeloIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.LancamentosFuturos.FirstOrDefaultAsync(h => h.Id == id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
