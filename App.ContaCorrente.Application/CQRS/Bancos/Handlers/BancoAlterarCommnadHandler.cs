using App.ContaCorrente.Application.CQRS.Bancos.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.CQRS.Bancos.Handlers
{
    public class BancoAlterarCommnadHandler : IRequestHandler<BancoAlterarCommnad, Banco>
    {
        private readonly IBancoRepositorio _bancoRepositorio;
        public BancoAlterarCommnadHandler(IBancoRepositorio bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
        }

        public async Task<Banco> Handle(BancoAlterarCommnad request, CancellationToken cancellationToken)
        {
            var banco = await _bancoRepositorio.GetBancosPeloIdAsync(request.Id);

            if (banco == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }
            else
            {
                banco.Atualizar(request.Nome,request.NomeCompleto);

                return await _bancoRepositorio.AlterarAsync(banco);
            }
        }
    }
}
