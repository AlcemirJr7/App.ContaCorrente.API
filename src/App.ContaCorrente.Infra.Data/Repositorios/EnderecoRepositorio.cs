using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace App.ContaCorrente.Infra.Data.Repositorios
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public EnderecoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }
        public async Task<Endereco> AlterarAsync(Endereco endereco)
        {
            try
            {
                _appDbContexto.Update(endereco);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoAlterarEntidade);
            }

            return endereco;
        }

        public async Task<Endereco> CriarAsync(Endereco endereco)
        {
            try
            {
                _appDbContexto.Add(endereco);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            return endereco;
            

        }

        public async Task<Endereco> DeletarAsync(Endereco endereco)
        {
            try
            {
                _appDbContexto.Enderecos.Remove(endereco);
                await _appDbContexto.SaveChangesAsync();
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoDeletarEntidade);
            }

            return endereco;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);  
        }

        public async Task<Endereco> GetPeloIdAsync(int? id)
        {
            try
            {
                return await _appDbContexto.Enderecos.FirstOrDefaultAsync(e => e.Id == id);
            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
                        
        }
    }
}
