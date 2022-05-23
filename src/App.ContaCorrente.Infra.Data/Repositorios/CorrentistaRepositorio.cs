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
    public class CorrentistaRepositorio : ICorrentistaRepositorio
    {
        private AppDbContexto _appDbContexto;

        public CorrentistaRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public Task<Correntista> AlterarAsync(Correntista correntista)
        {
            throw new NotImplementedException();
        }

        public async Task<Correntista> CriarAsync(Correntista correntista)
        {
            try
            {
                _appDbContexto.Add(correntista);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return correntista;

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<Correntista> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<Correntista> GetPeloPessoaIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
