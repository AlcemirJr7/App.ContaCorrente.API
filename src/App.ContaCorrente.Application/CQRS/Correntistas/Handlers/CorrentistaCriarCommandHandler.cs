using App.ContaCorrente.Application.CQRS.Correntistas.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
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
    public class CorrentistaCriarCommandHandler : IRequestHandler<CorrentistaCriarCommand, Correntista>
    {
        private readonly ICorrentistaRepositorio _correntistaRepositorio;
        private readonly IBancoRepositorio _bancoRepositorio;
        private readonly ILocalTrabalhoRepositorio _localTrabalhoRepositorio;
        private readonly IPessoaRepositorio _pessoaRepositorio;
        private readonly IEnderecoRepositorio _enderecoRepositorio;
        public CorrentistaCriarCommandHandler(ICorrentistaRepositorio correntistaRepositorio, IBancoRepositorio bancoRepositorio, 
                                              ILocalTrabalhoRepositorio localTrabalhoRepositorio, IPessoaRepositorio pessoaRepositorio,
                                              IEnderecoRepositorio enderecoRepositorio)
        {
            _correntistaRepositorio = correntistaRepositorio;
            _bancoRepositorio = bancoRepositorio;
            _localTrabalhoRepositorio = localTrabalhoRepositorio;
            _pessoaRepositorio = pessoaRepositorio;
            _enderecoRepositorio = enderecoRepositorio;
        }

        public async Task<Correntista> Handle(CorrentistaCriarCommand request, CancellationToken cancellationToken)
        {
            var banco = await _bancoRepositorio.GetBancosPeloIdAsync(request.BancoId);
            
            if (banco == null)
            {
                throw new DomainException(Mensagens.BancoInvalido);
            }

            var pessoa = await _pessoaRepositorio.GetPeloIdAsync(request.PessoaId);

            if (pessoa == null)
            {
                throw new DomainException(Mensagens.PessoaInvalida);
            }

            if(pessoa.TipoPessoa == EnumPessoa.PessoaFisica)
            {
                var localTrabalho = await _localTrabalhoRepositorio.GetPeloIdAsync(request.LocalTrabalhoId);

                if (localTrabalho == null)
                {
                    throw new DomainException(Mensagens.LocalTrabalhoInvalido);
                }
                
            }

            var endereco = await _enderecoRepositorio.GetPeloIdAsync(pessoa.EnderecoId);

            if(endereco == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(Endereco)));
            }

            if (request.LocalTrabalhoId == 0) request.LocalTrabalhoId = null;

            var correntista = new Correntista(request.Agencia,request.Conta,request.DataInicio,request.DataEncerramento,request.FlagConta,request.PessoaId,request.BancoId,request.LocalTrabalhoId);

            if(correntista == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(Correntista)));
            }
            else
            {
                return await _correntistaRepositorio.CriarAsync(correntista);
            }
        }
    }
}
