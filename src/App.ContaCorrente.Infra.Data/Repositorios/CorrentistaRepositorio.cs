using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class CorrentistaRepositorio : ICorrentistaRepositorio
    {
        private AppDbContexto _appDbContexto;

        public CorrentistaRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<Correntista> AlterarAsync(Correntista correntista)
        {
            try
            {
                _appDbContexto.Update(correntista);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoAtualizarEntidade);
            }

            return correntista;
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

        public async Task<Correntista> GetPeloIdAsync(int? id)
        {
            try
            {
                Correntista correntista = new Correntista();

                correntista = await _appDbContexto.Correntistas.FirstOrDefaultAsync(c => c.Id == id);

                return correntista;
                
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
            
        }   
        
        public async Task<Correntista> GetPelaContaAgenciaBancoAsync(int? banco, string? agencia, string? conta)
        {
            try
            {
                return await _appDbContexto.Correntistas.Where(c => c.BancoId == banco && c.Conta == conta && c.Agencia == agencia).FirstOrDefaultAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
