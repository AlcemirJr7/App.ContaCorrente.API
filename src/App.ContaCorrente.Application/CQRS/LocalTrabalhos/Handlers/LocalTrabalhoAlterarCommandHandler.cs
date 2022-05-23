using App.ContaCorrente.Application.CQRS.LocalTrabalhos.Commands;
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

namespace App.ContaCorrente.Application.CQRS.LocalTrabalhos.Handlers
{
    public class LocalTrabalhoAlterarCommandHandler : IRequestHandler<LocalTrabalhoAlterarCommand, LocalTrabalho>
    {
        private readonly ILocalTrabalhoRepositorio _localTrabalhoRepositorio;
        public LocalTrabalhoAlterarCommandHandler(ILocalTrabalhoRepositorio localTrabalhoRepositorio)
        {
            _localTrabalhoRepositorio = localTrabalhoRepositorio;
        }
        public async Task<LocalTrabalho> Handle(LocalTrabalhoAlterarCommand request, CancellationToken cancellationToken)
        {
            var localTrabalho = await _localTrabalhoRepositorio.GetPeloIdAsync(request.Id);

            if (localTrabalho == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(LocalTrabalho)));
            }
            else
            {
                localTrabalho.Atualizar(request.NomeEmpresa, request.NumeroDocumento, request.NumeroTelefone1, request.NumeroTelefone2, request.Email1, request.Email2,
                                        request.Salario1, request.Salario2);

                return await _localTrabalhoRepositorio.AlterarAsync(localTrabalho);

            }

            
            
        }
    }
}
