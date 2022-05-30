using App.ContaCorrente.Application.CQRS.ChavesPix.Commands;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ChavesPix.Handlers
{
    public class ChavePixCriarCommandHandler : IRequestHandler<ChavePixCriarCommand, ChavePix>
    {
        private readonly IChavePixRepositorio _chavePixRepositorio;
        public ChavePixCriarCommandHandler(IChavePixRepositorio chavePixRepositorio)
        {
            _chavePixRepositorio = chavePixRepositorio;
        }

        public async Task<ChavePix> Handle(ChavePixCriarCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var buscaChavePixAtiva = await _chavePixRepositorio.GetChavePixAtivaPeloCorrentistaIdAsync(request.CorrentistaId);

                if(buscaChavePixAtiva != null)
                {
                    throw new DomainException(Mensagens.ChavePixJaCadastradaParaCorrentista);
                }

                var chavePix = new ChavePix(request.Chave,DateTime.Now,request.TipoChave,EnumChavePixSituacao.Ativo,request.CorrentistaId);

                return await _chavePixRepositorio.CriarAsync(chavePix);
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
                throw new DomainException(Mensagens.ErroAoCriarChavePix);
            }
        }
    }
}
