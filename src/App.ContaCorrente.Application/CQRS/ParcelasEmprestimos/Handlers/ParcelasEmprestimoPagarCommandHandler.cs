using App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Commands;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Handlers
{
    public class ParcelasEmprestimoPagarCommandHandler : IRequestHandler<ParcelasEmprestimoPagarCommand, IEnumerable<ParcelasEmprestimo>>
    {
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;           
        private readonly IParcelasEmprestimoRepositorio _parcelasEmprestimoRepositorio;        
        private readonly IParcelasEmprestimoServico _parcelasEmprestimoServico;        
        
        public ParcelasEmprestimoPagarCommandHandler(IEmprestimoRepositorio emprestimoRepositorio, IParcelasEmprestimoRepositorio parcelasEmprestimoRepositorio,
                                                     IParcelasEmprestimoServico parcelasEmprestimoServico)
        {
            _emprestimoRepositorio = emprestimoRepositorio;
            _parcelasEmprestimoRepositorio = parcelasEmprestimoRepositorio;                      
            _parcelasEmprestimoServico = parcelasEmprestimoServico;            
        }

        public async Task<IEnumerable<ParcelasEmprestimo>> Handle(ParcelasEmprestimoPagarCommand request, CancellationToken cancellationToken)
        {
            var emprestimos = await _emprestimoRepositorio.GetEmprestimosEfetivadosEmAbertoAsync();

            var listaParcelasPagas = new List<ParcelasEmprestimo>();
            try
            {
                foreach (var emprestimo in emprestimos)
                {
                    var ParcelasEmprestimo = await _parcelasEmprestimoRepositorio.GetParcelasAhVencerAsync(emprestimo.Id);

                    foreach (var parcela in ParcelasEmprestimo)
                    {

                        var parcelaEfetivadaDto = await _parcelasEmprestimoServico.EfetivaPagamentoParcelaEmprestimoAsync(emprestimo,parcela);

                        if(parcelaEfetivadaDto != null)
                        {
                            listaParcelasPagas.Add(parcela);
                        }
                                               
                    }
                }

            }
            catch (DomainException e)
            {
                throw new DomainException(e.Message);
            }
            catch (DomainExcepitonValidacao e)
            {
                throw new DomainExcepitonValidacao(e.Message);
            }
            catch
            {
                throw new DomainException(Mensagens.ErroAoProcessarPagamentoParcelasEmprestimo);
            }
            
            return listaParcelasPagas;

        }
    }
}
