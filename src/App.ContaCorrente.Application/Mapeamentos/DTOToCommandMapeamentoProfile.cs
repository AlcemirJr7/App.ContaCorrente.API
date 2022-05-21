using App.ContaCorrente.Application.CQRS.Bancos.Commands;
using App.ContaCorrente.Application.DTOs;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Mapeamentos
{
    public class DTOToCommandMapeamentoProfile : Profile
    {
        public DTOToCommandMapeamentoProfile()
        {
            CreateMap<BancoDTO, BancoCriarCommnad>();
            CreateMap<BancoDTO, BancoAlterarCommnad>();
            
        }
    }
}
