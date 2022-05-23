using App.ContaCorrente.Application.CQRS.Correntistas.Queries;
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

namespace App.ContaCorrente.Application.CQRS.Correntistas.Handlers
{
    public class GetCorrentistaPeloIdQueryHandler : IRequestHandler<GetCorrentistaPeloIdQuery, Correntista>
    {
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        private readonly ILocalTrabalhoRepositorio _localTrabalhoRepositorio;
        private readonly IBancoRepositorio _bancoRepositorio;
        private readonly IPessoaRepositorio _pessooaRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public GetCorrentistaPeloIdQueryHandler(ICorrentistaRepositorio correntistaRepositorio, ILocalTrabalhoRepositorio localTrabalhoRepositorio,
                                                IBancoRepositorio bancoRepositorio, IPessoaRepositorio pessooaRepositorio, IEnderecoRepositorio enderecoRepositorio)
        {
            _correntistaRepositorio = correntistaRepositorio;
            _bancoRepositorio = bancoRepositorio;
            _localTrabalhoRepositorio = localTrabalhoRepositorio;
            _pessooaRepositorio = pessooaRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }
        public async Task<Correntista> Handle(GetCorrentistaPeloIdQuery request, CancellationToken cancellationToken)
        {
            try
            {                
                var correntista = await _correntistaRepositorio.GetPeloIdAsync(request.Id);

                if (correntista == null)
                {
                    throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(Correntista)));
                }

                var pessoa = await _pessooaRepositorio.GetPeloIdAsync(correntista.PessoaId);

                var endereco = await _enderecoRepositorio.GetPeloIdAsync(pessoa.EnderecoId);

                var localPessoa = await _localTrabalhoRepositorio.GetPeloIdAsync(correntista.LocalTrabalhoId);

                var banco = await _bancoRepositorio.GetBancosPeloIdAsync(correntista.BancoId);

                return correntista;

            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoEfetuarConsulta);
            }
        }
    }
}
