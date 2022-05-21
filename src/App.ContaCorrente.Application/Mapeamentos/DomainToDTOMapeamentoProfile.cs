using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Domain.Entidades;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Mapeamentos
{
    public class DomainToDTOMapeamentoProfile : Profile
    {
        public DomainToDTOMapeamentoProfile()
        {
            CreateMap<Banco, BancoDTO>().ReverseMap();
            CreateMap<Endereco, EnderecoDTO>().ReverseMap();

        }
    }
}
