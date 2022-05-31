﻿using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Entidades.Transferencia;
using AutoMapper;

namespace App.ContaCorrente.Application.Mapeamentos
{
    public class DomainToDTOMapeamentoProfile : Profile
    {
        public DomainToDTOMapeamentoProfile()
        {
            CreateMap<Banco, BancoDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();
            CreateMap<Historico, HistoricoDTO>().ReverseMap();
            CreateMap<Correntista, CorrentistaDTO>().ReverseMap();
            CreateMap<LocalTrabalho, LocalTrabalhoDTO>().ReverseMap();
            CreateMap<Pessoa, PessoaDTO>().ReverseMap();
            CreateMap<Correntista, CorrentistaDTO>().ReverseMap();
            CreateMap<Correntista, CorrentistaAlteraDTO>().ReverseMap();
            CreateMap<SaldoContaCorrente, SaldoContaCorrenteDTO>().ReverseMap();
            CreateMap<Lancamento, LancamentoDTO>().ReverseMap();
            CreateMap<Pagamento, PagamentoDTO>().ReverseMap();
            CreateMap<Pagamento, PagamentoAgendaDTO>().ReverseMap();
            CreateMap<LancamentoFuturo, LancamentoFuturoDTO>().ReverseMap();
            CreateMap<Emprestimo, EmprestimoDTO>().ReverseMap();
            CreateMap<Emprestimo, EmprestimoEfetivarDTO>().ReverseMap();
            CreateMap<ParcelasEmprestimo, ParcelasEmprestimoDTO>().ReverseMap();
            CreateMap<ParcelasEmprestimo, ParcelasEmprestimoAntecipaDTO>().ReverseMap();
            CreateMap<ChavePix, ChavePixDTO>().ReverseMap();
            CreateMap<Transferencia, TransferenciaInternaPixDTO>().ReverseMap();
            

        }
    }
}
