using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class ParcelasEmprestimoRepositorio : IParcelasEmprestimoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public ParcelasEmprestimoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public Task<ParcelasEmprestimo> AlterarAsync(ParcelasEmprestimo parcelasEmprestimo)
        {
            throw new NotImplementedException();
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

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public Task<IEnumerable<ParcelasEmprestimo>> GetPeloEmprestimoIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParcelasEmprestimo>> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
