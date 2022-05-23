using App.ContaCorrente.Application.CQRS.LocalTrabalhos.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;


namespace App.ContaCorrente.Application.CQRS.LocalTrabalhoPessoas.Handlers
{
    public class LocalTrabalhoCriarCommandHandler : IRequestHandler<LocalTrabalhoCriarCommand, LocalTrabalho>
    {
        private readonly ILocalTrabalhoRepositorio _localTrabalhoRepositorio;       
        public LocalTrabalhoCriarCommandHandler(ILocalTrabalhoRepositorio localTrabalhoRepositorio)
        {
            _localTrabalhoRepositorio = localTrabalhoRepositorio;
        }

        public async Task<LocalTrabalho> Handle(LocalTrabalhoCriarCommand request, CancellationToken cancellationToken)
        {
            var localTrabalhoPessoa = new LocalTrabalho(request.NomeEmpresa,request.NumeroDocumento,request.NumeroTelefone1,request.NumeroTelefone2,
                                                        request.Email1,request.Email2,request.Salario1,request.Salario2);
            
            if(localTrabalhoPessoa == null)
            {
                throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada,nameof(LocalTrabalho)));
            }
            else
            {
                localTrabalhoPessoa.DataCadastro = DateTime.Now;
                return await _localTrabalhoRepositorio.CriarAsync(localTrabalhoPessoa);
                
            }
        }
    }
}
