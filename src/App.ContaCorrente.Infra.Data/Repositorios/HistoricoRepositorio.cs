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
    public class HistoricoRepositorio : IHistoricoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public HistoricoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<Historico> AlterarAsync(Historico historico)
        {
            try
            {
                _appDbContexto.Update(historico);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoAlterarEntidade);
            }

            return historico;
        }

        public async Task<Historico> CriarAsync(Historico historico)
        {
            try
            {
                _appDbContexto.Add(historico);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return historico;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Historico>> GetHistoricosAsync()
        {
            try
            {
                var historicos = await _appDbContexto.Historicos.ToListAsync();
                return historicos;
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<Historico> GetPeloIdAsync(int? id)
        {
            try
            {
                var historico = await _appDbContexto.Historicos.FirstOrDefaultAsync(h => h.Id == id);
                return historico;

            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }

        }
    }
}
