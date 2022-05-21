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
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private AppDbContexto _appDbContexto;
        public EnderecoRepositorio(AppDbContexto appDbContexto)
        {
            _appDbContexto = appDbContexto;
        }
        public Task<Endereco> AlterarAsync(Endereco endereco)
        {
            throw new NotImplementedException();
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

        public Task<Endereco> DeletarAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);  
        }

        public async Task<Endereco> GetPeloIdAsync(int? id)
        {
            var endereco = await _appDbContexto.Enderecos.FirstOrDefaultAsync(e => e.Id == id);

            return endereco;
        }
    }
}
