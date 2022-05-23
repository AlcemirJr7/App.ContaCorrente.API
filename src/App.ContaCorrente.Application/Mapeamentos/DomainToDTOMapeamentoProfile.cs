using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;
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

        }
    }
}
