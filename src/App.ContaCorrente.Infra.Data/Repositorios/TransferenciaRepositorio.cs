using App.ContaCorrente.Domain.Entidades.Transferencia;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class TransferenciaRepositorio : ITransferenciaRepositorio
    {
        private AppDbContexto _appDbContexto;

        public TransferenciaRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public Task<Transferencia> AlterarAsync(Transferencia transferencia)
        {
            throw new NotImplementedException();
        }

        public async Task<Transferencia> CriarAsync(Transferencia transferencia)
        {
            try
            {
                _appDbContexto.Add(transferencia);
                await _appDbContexto.SaveChangesAsync();

                return transferencia;
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
        }

        public Task<Transferencia> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
