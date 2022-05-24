using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class LancamentoRepositorio : ILancamentoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public LancamentoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }       

        public async Task<Lancamento> CriarAsync(Lancamento lancamento)
        {
            try
            {
                _appDbContexto.Add(lancamento);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return lancamento;
        }

        public async Task<Lancamento> DeletarAsync(int? id)
        {
            var lancamento = await GetPeloIdAsync(id);

            if(lancamento == null)
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }

            try
            {                
                _appDbContexto.Remove(lancamento);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoDeletarEntidade);
            }

            return lancamento;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Lancamento>> GetPeloCorrentistaIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.Lancamentos.Where(l => l.CorrentistaId == id).ToListAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<Lancamento> GetPeloIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.Lancamentos.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
