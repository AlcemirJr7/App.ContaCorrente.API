using App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Commands;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Handlers
{
    public class ParcelasEmprestimoPagarAntecipadoCommandHandler : IRequestHandler<ParcelasEmprestimoPagarAntecipadoCommand, IEnumerable<ParcelasEmprestimo>>
    {
        private readonly IParcelasEmprestimoServico _parcelasEmprestimoServico;
        private readonly IEmprestimoRepositorio _emprestimoRepositorio;
        private readonly IParcelasEmprestimoRepositorio _parcelasEmprestimoRepositorio;
        private readonly IMapper _mapper;
        public ParcelasEmprestimoPagarAntecipadoCommandHandler(IParcelasEmprestimoServico parcelasEmprestimoServico, IEmprestimoRepositorio emprestimoRepositorio,
                                                               IMapper mapper, IParcelasEmprestimoRepositorio parcelasEmprestimoRepositorio)
        {
            _parcelasEmprestimoServico = parcelasEmprestimoServico;
            _emprestimoRepositorio = emprestimoRepositorio; 
            _mapper = mapper;
            _parcelasEmprestimoRepositorio = parcelasEmprestimoRepositorio;
        }

        public async Task<IEnumerable<ParcelasEmprestimo>> Handle(ParcelasEmprestimoPagarAntecipadoCommand request, CancellationToken cancellationToken)
        {

            var emprestimo = await _emprestimoRepositorio.GetPeloIdAsync(request.EmprestimoId);

            var listaParcelasEmprestimo = new List<ParcelasEmprestimo>();
            try
            {
                if (emprestimo == null)
                {
                    throw new DomainException(String.Format(Mensagens.EntidadeNaoCarregada, nameof(Emprestimo)));
                }

                var parcela = await _parcelasEmprestimoRepositorio.GetSeqParcelaAsync(request.SeqParcelas,request.EmprestimoId);

                var parcelaPaga = await _parcelasEmprestimoServico.EfetivaPagamentoParcelaEmprestimoAsync(emprestimo, parcela);

                parcela = _mapper.Map<ParcelasEmprestimo>(parcelaPaga);

                listaParcelasEmprestimo.Add(parcela);   

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

            return listaParcelasEmprestimo;





        }
    }
}
