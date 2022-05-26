using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class EmprestimoRepositorio : IEmprestimoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public EmprestimoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;

        }
        public async Task<Emprestimo> AlterarAsync(Emprestimo emprestimo)
        {
            try
            {
                _appDbContexto.Update(emprestimo);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoAlterarEntidade);
            }

            return emprestimo;
        }

        public async Task<Emprestimo> CriarAsync(Emprestimo emprestimo)
        {
            try
            {
                _appDbContexto.Add(emprestimo);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return emprestimo;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<Emprestimo>> GetPeloCorrentistaIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.Emprestimos.Where(e => e.CorrentistaId == id).ToListAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<Emprestimo> GetPeloIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.Emprestimos.FirstOrDefaultAsync(e => e.Id == id);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

        public async Task<IEnumerable<Emprestimo>> GetEmprestimosEfetivadosPeloCorrentistaIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.Emprestimos.Where(e => e.CorrentistaId == id && e.FlagEstado == EnumFlagEstadoEmprestimo.Efetivado).ToListAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }

    }
}
