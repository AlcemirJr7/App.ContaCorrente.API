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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<IEnumerable<Lancamento>> GetPeloCorrentistaIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Lancamento> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
