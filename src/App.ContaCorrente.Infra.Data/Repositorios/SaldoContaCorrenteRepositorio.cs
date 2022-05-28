using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class SaldoContaCorrenteRepositorio : ISaldoContaCorrenteRepositorio
    {
        private AppDbContexto _appDbContexto;

        public SaldoContaCorrenteRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }
        public async Task<SaldoContaCorrente> AlterarAsync(SaldoContaCorrente saldoContaCorrente)
        {
            try
            {
                _appDbContexto.Update(saldoContaCorrente);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoAlterarEntidade);
            }

            return saldoContaCorrente;
        }

        public async Task<SaldoContaCorrente> CriarAsync(SaldoContaCorrente saldoContaCorrente)
        {
            try
            {
                _appDbContexto.Add(saldoContaCorrente);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return saldoContaCorrente;
        }

        public async Task<SaldoContaCorrente> GetPeloCorrentistaIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.SaldoContaCorrente.FirstOrDefaultAsync(p => p.CorrentistaId == id);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<SaldoContaCorrente> GetPeloIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.SaldoContaCorrente.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
