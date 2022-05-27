using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class PagamentoRepositorio : IPagamentoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public PagamentoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        
        public async Task<Pagamento> CriarAsync(Pagamento pagamento)
        {
            try
            {
                _appDbContexto.Add(pagamento);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return pagamento;
        }

        public async Task<Pagamento> AtualizarAsync(Pagamento pagamento)
        {
            try
            {
                _appDbContexto.Update(pagamento);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoAtualizarEntidade);
            }

            return pagamento;
        }

        public async Task<Pagamento> DeletarAsync(int? id)
        {
            var pagamento = await GetPeloIdAsync(id);

            if(pagamento == null)
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }

            try
            {
                _appDbContexto.Remove(pagamento);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoDeletarEntidade);
            }

            return pagamento;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Pagamento>> GetPeloCorrentistaIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.Pagamentos.Where(p => p.CorrentistaId == id).ToListAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<Pagamento> GetPeloIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.Pagamentos.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }

        }
    }
}
