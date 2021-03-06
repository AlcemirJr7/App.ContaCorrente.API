using App.ContaCorrente.Application.CQRS.Bancos.Commands;
using App.ContaCorrente.Application.CQRS.ChavesPix.Commands;
using App.ContaCorrente.Application.CQRS.Correntistas.Commands;
using App.ContaCorrente.Application.CQRS.Emprestimos.Commands;
using App.ContaCorrente.Application.CQRS.Enderecos.Commands;
using App.ContaCorrente.Application.CQRS.Historicos.Commands;
using App.ContaCorrente.Application.CQRS.Lancamentos.Commands;
using App.ContaCorrente.Application.CQRS.LancamentosFuturos.Commands;
using App.ContaCorrente.Application.CQRS.LocalTrabalhos.Commands;
using App.ContaCorrente.Application.CQRS.Pagamentos.Commands;
using App.ContaCorrente.Application.CQRS.ParcelasEmprestimos.Commands;
using App.ContaCorrente.Application.CQRS.Pessoas.Commands;
using App.ContaCorrente.Application.CQRS.Transferencias.Commands;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;
using AutoMapper;

namespace App.ContaCorrente.Application.Mapeamentos
{
    public class DTOToCommandMapeamentoProfile : Profile
    {
        public DTOToCommandMapeamentoProfile()
        {
            //Banco
            CreateMap<BancoDTO, BancoCriarCommnad>();
            CreateMap<BancoDTO, BancoAlterarCommnad>();

            //Endereco
            CreateMap<EnderecoDTO, EnderecoCriarCommand>();
            CreateMap<EnderecoDTO, EnderecoAlterarCommand>();
            CreateMap<EnderecoDTO, EnderecoDeletarCommand>();

            //Historico
            CreateMap<HistoricoDTO, HistoricoCriarCommand>();
            CreateMap<HistoricoDTO, HistoricoAlterarCommand>();

            //LocalTrabalhoPessoa
            CreateMap<LocalTrabalhoDTO, LocalTrabalhoCriarCommand>();
            CreateMap<LocalTrabalhoDTO, LocalTrabalhoAlterarCommand>();

            //Pessoa
            CreateMap<PessoaDTO, PessoaCriarCommand>();
            CreateMap<PessoaDTO, PessoaAlterarCommand>();

            //Correntista
            CreateMap<CorrentistaDTO, CorrentistaCriarCommand>();
            CreateMap<CorrentistaAlteraDTO, CorrentistaAlterarCommand>();

            //Lancamento
            CreateMap<LancamentoDTO, LancamentoCriarCommand>();

            //Pagamento
            CreateMap<PagamentoDTO, PagamentoCriarCommand>();
            CreateMap<PagamentoAgendaDTO, PagamentoCriarAgendamentoCommand>();
            

            //LancamentoFuturo
            CreateMap<LancamentoFuturoDTO, LancamentoFuturoCriarCommand>();
            CreateMap<LancamentoFuturoDTO, LancamentoFuturoEfetivarCommand>();
            CreateMap<LancamentoFuturoDTO, LancamentoFuturoCancelarCommand>();
            

            //Emprestimo
            CreateMap<EmprestimoDTO, EmprestimoCriarCommand>();
            CreateMap<EmprestimoDTO, EmprestimoAlterarCommand>();
            CreateMap<EmprestimoDTO, EmprestimoEfetivarCommand>();
            CreateMap<Emprestimo, EmprestimoEfetivarCommand>();

            //Parclas Emprestimo
            CreateMap<ParcelasEmprestimoDTO, ParcelasEmprestimoPagarCommand>();
            CreateMap<ParcelasEmprestimoAntecipaDTO, ParcelasEmprestimoPagarAntecipadoCommand>();
            CreateMap<ParcelasEmprestimo, ParcelasEmprestimoPagarAntecipadoCommand>();

            //ChavePix
            CreateMap<ChavePixDTO, ChavePixCriarCommand>();
            CreateMap<ChavePixDTO, ChavePixInativarCommand>();

            //Transferencia
            CreateMap<TransferenciaInternaPixDTO, TransferenciaInternaPixCriarCommand>();
            CreateMap<TransferenciaInternaTedDTO, TransferenciaInternaTedCriarCommand>();
            CreateMap<TransferenciaInternaPixAgendaDTO, TransferenciaInternaPixCriarAgendamentoCommand>();
            CreateMap<TransferenciaExternaEnviaPixDTO, TransferenciaExternaPixCriarEnvioCommand>();
            CreateMap<TransferenciaExternaEnviaTedDTO, TransferenciaExternaTedCriaEnvioCommand>();


            








        }
    }
}
