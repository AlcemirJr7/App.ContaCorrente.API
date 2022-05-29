using App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Commands;
using App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Queries;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
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
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        private readonly IEmprestimoServico _emprestimoServico;
        private readonly IParcelasEmprestimoRepositorio _parcelasEmprestimoRepositorio;
        public ParcelasEmprestimoServico(IMediator mediator, IMapper mapper, IEmprestimoServico emprestimoServico, ILancamentoRepositorio lancamentoRepositorio,
                                         ISaldoContaCorrenteServico saldoContaCorrenteServico, IParcelasEmprestimoRepositorio parcelasEmprestimoRepositorio)
        {
            _mediator = mediator;
            _mapper = mapper;
            _emprestimoServico = emprestimoServico;
            _lancamentoRepositorio = lancamentoRepositorio;
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
            _parcelasEmprestimoRepositorio = parcelasEmprestimoRepositorio;
        }

        public Task<ParcelasEmprestimoDTO> AlterarAsync(ParcelasEmprestimoDTO parcelasEmprestimoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ParcelasEmprestimoDTO>> GetPeloEmprestimoIdAsync(int? id)
        {
            var parcelasQuery = new GetParcelasEmprestimoPeloEmprestimoIdQuery(id.Value);

            if(parcelasQuery == null)
            {
                throw new DomainException(Mensagens.ErroAoCriarEntidade);
            }

            var result = await _mediator.Send(parcelasQuery);

            var parcelas = _mapper.Map<IEnumerable<ParcelasEmprestimoDTO>>(result);

            return parcelas;

        }

        public async Task<IEnumerable<ParcelasEmprestimoDTO>> ProcessaPagamentoParcelasEmprestimoAsync()
        {
            var parcelaEmprestimoCommand = new ParcelasEmprestimoPagarCommand();

            var result = await _mediator.Send(parcelaEmprestimoCommand);

            var parcelasEmprestimo = _mapper.Map<IEnumerable<ParcelasEmprestimoDTO>>(result);

            return parcelasEmprestimo;
        }

        public Task<IEnumerable<ParcelasEmprestimoDTO>> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public async Task<ParcelasEmprestimoDTO> EfetivaPagamentoParcelaEmprestimoAsync(Emprestimo emprestimo, ParcelasEmprestimo parcela)
        {
            ParcelasEmprestimoDTO? parcelaDto = null;

            try
            {
                await _saldoContaCorrenteServico.ValidaSaldoAsync(emprestimo.CorrentistaId, (int)EnumParcelasEmprestimoHistorico.Historico, parcela.Valor);
            }
            catch
            {
                return parcelaDto;
            }

            var lancamento = new Lancamento(DateTime.Now, parcela.Valor, $"Pagamento parcela: {parcela.SeqParcelas}  emprestimo ID: {emprestimo.Id}",
                                            emprestimo.CorrentistaId, (int)EnumParcelasEmprestimoHistorico.Historico);

            var lancamentoCriado = await _lancamentoRepositorio.CriarAsync(lancamento);

            await _saldoContaCorrenteServico.AtulizaSaldoAsync(lancamentoCriado.CorrentistaId, lancamentoCriado.HistoricoId, lancamentoCriado.Valor);

            parcela.Atualizar(parcela.Valor, parcela.SeqParcelas, parcela.DataVencimento, DateTime.Now, emprestimo.Id);

            var parcelaAlterada = await _parcelasEmprestimoRepositorio.AlterarAsync(parcela);

            await _emprestimoServico.AtualizaSaldoDevedorAsync(parcela.Valor, emprestimo);

            return _mapper.Map<ParcelasEmprestimoDTO>(parcelaAlterada);


        }

        public async Task<IEnumerable<ParcelasEmprestimoAntecipaDTO>> PagamentoAntecipadoParcelaEmprestimoAsync(IEnumerable<ParcelasEmprestimoAntecipaDTO> parcelasDto)
        {

            var listaParcelaEmprestimo = new List<ParcelasEmprestimoAntecipaDTO>();

            foreach (var parcela in parcelasDto)
            {
                var parcelaEmprestimoCommand = _mapper.Map<ParcelasEmprestimoPagarAntecipadoCommand>(parcela);

                var result = await _mediator.Send(parcelaEmprestimoCommand);

                var parcelaEmprestimo = _mapper.Map<ParcelasEmprestimoAntecipaDTO>(result);

                parcelaEmprestimo.mensagem = Mensagens.PagamentoAntecipadoParcelaEmprestimo;

                listaParcelaEmprestimo.Add(parcelaEmprestimo);
            }

            return listaParcelaEmprestimo;
        }

        public IEnumerable<ParcelasEmprestimoDTO> GerarParcelasEmprestimo(Emprestimo emprestimo)
        {
            List<ParcelasEmprestimoDTO> listaParcelas  = new  List<ParcelasEmprestimoDTO>();

            try
            {
                var dataVencimento = Convert.ToDateTime(emprestimo.DataEfetivacao.Value.ToString("dd/MM/yyyy")).AddMonths(1);

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
