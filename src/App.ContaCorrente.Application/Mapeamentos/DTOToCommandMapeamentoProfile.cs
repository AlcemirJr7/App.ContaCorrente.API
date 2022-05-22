using App.ContaCorrente.Application.CQRS.Bancos.Commands;
using App.ContaCorrente.Application.CQRS.Enderecos.Commands;
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
            //Banco
            CreateMap<BancoDTO, BancoCriarCommnad>();
            CreateMap<BancoDTO, BancoAlterarCommnad>();

            //Endereco
            CreateMap<EnderecoDTO, EnderecoCriarCommand>();
            CreateMap<EnderecoDTO, EnderecoAlterarCommand>();
            CreateMap<EnderecoDTO, EnderecoDeletarCommand>();

            //Historico
            CreateMap<HistoricoDTO, EnderecoCriarCommand>();
            CreateMap<HistoricoDTO, EnderecoAlterarCommand>();
        }
    }
}
