using App.ContaCorrente.Application.CQRS.Bancos.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using System.Runtime.Serialization;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Bancos.Handlers
{
    public class BancoCriarCommnadHandler : IRequestHandler<BancoCriarCommnad, Banco>
    {
        private readonly IBancoRepositorio _bancoRepositorio;
        public BancoCriarCommnadHandler(IBancoRepositorio bancoRepositorio)
        {
            _bancoRepositorio = bancoRepositorio;
        }        

        public async Task<Banco> Handle(BancoCriarCommnad request, CancellationToken cancellationToken)
        {
            var buscaBanco = await _bancoRepositorio.GetBancosPeloIdAsync(request.Id);

            if(buscaBanco == null)
            {
                Banco banco = new Banco(request.Id, request.Nome, request.NomeCompleto);

                if (banco == null)
                {
                    throw new DomainException(Mensagens.ErroAoCriarEntidade);
                }
                else
                {
                    var result = await _bancoRepositorio.CriarAsync(banco);

                    return result;
                }
            }else
            {
                throw new DomainException(String.Format(Mensagens.BancoJaExistente, request.Nome));               

            }

            
        }
    }
}
