using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class HistoricoRepositorio : IHistoricoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public HistoricoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<Historico> AlterarAsync(Historico historico)
        {
            try
            {
                _appDbContexto.Update(historico);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoAlterarEntidade);
            }

            return historico;
        }

        public async Task<Historico> CriarAsync(Historico historico)
        {
            try
            {
                _appDbContexto.Add(historico);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return historico;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Historico>> GetHistoricosAsync()
        {
            try
            {
                return await _appDbContexto.Historicos.ToListAsync();
                
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<Historico> GetPeloIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.Historicos.FirstOrDefaultAsync(h => h.Id == id);                
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }

        }
    }
}
