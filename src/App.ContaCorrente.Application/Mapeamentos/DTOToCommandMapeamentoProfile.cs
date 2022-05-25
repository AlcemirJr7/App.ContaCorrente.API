using App.ContaCorrente.Application.CQRS.Bancos.Commands;
using App.ContaCorrente.Application.CQRS.Correntistas.Commands;
using App.ContaCorrente.Application.CQRS.Emprestimos.Commands;
using App.ContaCorrente.Application.CQRS.Enderecos.Commands;
using App.ContaCorrente.Application.CQRS.Historicos.Commands;
using App.ContaCorrente.Application.CQRS.Lancamentos.Commands;
using App.ContaCorrente.Application.CQRS.LancamentosFuturos.Commands;
using App.ContaCorrente.Application.CQRS.LocalTrabalhos.Commands;
using App.ContaCorrente.Application.CQRS.Pagamentos.Commands;
using App.ContaCorrente.Application.CQRS.Pessoas.Commands;
using App.ContaCorrente.Application.DTOs;
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

            //LancamentoFuturo
            CreateMap<LancamentoFuturoDTO, LancamentoFuturoCriarCommand>();

            //Emprestimo
            CreateMap<EmprestimoDTO, EmprestimoCriarCommand>();
            CreateMap<EmprestimoDTO, EmprestimoAlterarCommand>();



        }
    }
}
