using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class LancamentoFuturoRepositorio : ILancamentoFuturoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public LancamentoFuturoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public Task<LancamentoFuturo> AlterarAsync(LancamentoFuturo lancamentoFuturo)
        {
            throw new NotImplementedException();
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

        public Task<IEnumerable<LancamentoFuturo>> GetPeloCorrentistaIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<LancamentoFuturo> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
