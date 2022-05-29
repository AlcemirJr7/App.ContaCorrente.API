using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class PessoaRepositorio : IPessoaRepositorio
    {
        private AppDbContexto _appDbContexto;
        public PessoaRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }

        public async Task<Pessoa> AlterarAsync(Pessoa pessoa)
        {
            try
            {
                _appDbContexto.Update(pessoa);
                await _appDbContexto.SaveChangesAsync();
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoAlterarEntidade);
            }

            return pessoa;
        }

        public async Task<Pessoa> CriarAsync(Pessoa pessoa)
        {
            try
            {
                _appDbContexto.Add(pessoa);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return pessoa;
        }

        public async Task<Pessoa> GetPeloIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.Pessoas.FirstOrDefaultAsync(p => p.Id == id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
