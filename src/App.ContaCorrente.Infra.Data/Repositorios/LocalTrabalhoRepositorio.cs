using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class LocalTrabalhoRepositorio : ILocalTrabalhoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public LocalTrabalhoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<LocalTrabalho> AlterarAsync(LocalTrabalho localTrabalho)
        {
            throw new NotImplementedException();
        }

        public async Task<LocalTrabalho> CriarAsync(LocalTrabalho localTrabalho)
        {
            try
            {
                _appDbContexto.Add(localTrabalho);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return localTrabalho;
        }

        public async Task<LocalTrabalho> DeletarAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public async Task<LocalTrabalho> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
