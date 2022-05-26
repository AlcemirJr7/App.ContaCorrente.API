using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using AutoMapper;
using MediatR;

namespace App.ContaCorrente.Application.Servicos
{
    public class ParcelasEmprestimoServico : IParcelasEmprestimoServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ParcelasEmprestimoServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public Task<ParcelasEmprestimoDTO> AlterarAsync(ParcelasEmprestimoDTO parcelasEmprestimoDto)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParcelasEmprestimoDTO>> GetPeloEmprestimoIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ParcelasEmprestimoDTO>> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<ParcelasEmprestimoDTO> GerarParcelasEmprestimo(Emprestimo emprestimo)
        {
            List<ParcelasEmprestimoDTO> listaParcelas  = new  List<ParcelasEmprestimoDTO>();

            try
            {
                var dataVencimento = emprestimo.DataEfetivacao.Value.AddMonths(1);

                for (int i = 0; i < emprestimo.QtdParcelas; i++)
                {
                    var parcela = new ParcelasEmprestimoDTO
                    {
                        SeqParcelas = i + 1,
                        DataVencimento = dataVencimento,
                        EmprestimoId = emprestimo.Id,
                        Valor = emprestimo.ValorParcela                        
                    };        

                    listaParcelas.Add(parcela);

                    dataVencimento = dataVencimento.AddMonths(1);
                }

                return listaParcelas;

            }
            catch 
            {
                throw new DomainException(Mensagens.ErroAoCriarParcelasEmprestimo);
            }
        }
    }
}
