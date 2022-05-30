using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class ChavePixRepositorio : IChavePixRepositorio
    {
        private AppDbContexto _appDbContexto;

        public ChavePixRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<ChavePix> AlterarAsync(ChavePix chavePix)
        {
            try
            {
                _appDbContexto.Update(chavePix);
                await _appDbContexto.SaveChangesAsync();
                return chavePix;
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
        }

        public async Task<ChavePix> CriarAsync(ChavePix chavePix)
        {
            try
            {
                _appDbContexto.Add(chavePix);
                await _appDbContexto.SaveChangesAsync();
                return chavePix;
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
        }

        public async Task<ChavePix> GetChavePixPelaChaveAsync(string? chave)
        {
            try
            {
                return await _appDbContexto.ChavesPix.FirstOrDefaultAsync(c => c.Chave == chave);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<ChavePix> GetChavePixPeloCorrentistaIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.ChavesPix.FirstOrDefaultAsync(c => c.CorrentistaId == id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<ChavePix> GetChavePixAtivaPeloCorrentistaIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.ChavesPix.FirstOrDefaultAsync(c => c.CorrentistaId == id && c.Situacao == EnumChavePixSituacao.Ativo);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
