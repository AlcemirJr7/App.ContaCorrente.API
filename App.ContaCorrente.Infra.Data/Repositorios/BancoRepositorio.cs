using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class BancoRepositorio : IBancoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public BancoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }
        public async Task<Banco> AlterarAsync(Banco banco)
        {
            try
            {
                _appDbContexto.Bancos.Update(banco);
                await _appDbContexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new DomainException(Mensagens.ErroAoAtualizarEntidade,ex); 
            }

            return banco;
        }

        public async Task<Banco> CriarAsync(Banco banco)
        {
            try
            {
                _appDbContexto.Bancos.Add(banco);
                await _appDbContexto.SaveChangesAsync();
            }
            catch (Exception ex)
            {                
                throw new DomainException(Mensagens.ErroAoCriarEntidade,ex);
            }
            
            return banco;
        }
        
        public void Dispose()
        {            
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Banco>> GetBancosAsync()
        {
            try
            {
                var result = await _appDbContexto.Bancos.ToListAsync();
                return result;
            }
            catch (Exception ex)
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta,ex);
            }
            
        }

        public async Task<Banco> GetBancosPeloIdAsync(int id)
        {
            try
            {
                var result = await _appDbContexto.Bancos.FirstOrDefaultAsync(b => b.Id == id);

                return result;
            }
            catch (Exception ex)
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta, ex); 
            }

        }
    }
}
