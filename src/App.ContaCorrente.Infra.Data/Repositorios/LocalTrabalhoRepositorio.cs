using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

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
            try
            {
                _appDbContexto.Update(localTrabalho);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoAlterarEntidade);
            }

            return localTrabalho;
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

        public async Task<LocalTrabalho> GetPeloIdAsync(int? id)
        {
            
            try
            {
                return await _appDbContexto.LocalTrabalhos.FirstOrDefaultAsync(l => l.Id == id);
                
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
