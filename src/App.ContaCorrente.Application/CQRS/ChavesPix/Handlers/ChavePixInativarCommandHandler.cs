using App.ContaCorrente.Application.CQRS.ChavesPix.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ChavesPix.Handlers
{
    public class ChavePixInativarCommandHandler : IRequestHandler<ChavePixInativarCommand, ChavePix>
    {
        private readonly IChavePixRepositorio _chavePixRepositorio;
        public ChavePixInativarCommandHandler(IChavePixRepositorio chavePixRepositorio)
        {
            _chavePixRepositorio = chavePixRepositorio;                
        }

        public async Task<ChavePix> Handle(ChavePixInativarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var chavePix = await _chavePixRepositorio.GetChavePixPeloCorrentistaIdAsync(request.CorrentistaId);

                if(chavePix == null)
                {
                    throw new DomainException(Mensagens.ChavePixNaoEncontrada);
                }

                chavePix.Atualizar(chavePix.Chave,chavePix.DataCadastro,chavePix.TipoChave,EnumChavePixSituacao.Inativo,chavePix.CorrentistaId);

                var chavePixAlterado = await _chavePixRepositorio.AlterarAsync(chavePix);

                return chavePixAlterado;

            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);

            }catch (DomainExcepitonValidacao e)
            {
                throw new DomainExcepitonValidacao(e.Message);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoAlterarChavePix);
            }
        }
    }
}
