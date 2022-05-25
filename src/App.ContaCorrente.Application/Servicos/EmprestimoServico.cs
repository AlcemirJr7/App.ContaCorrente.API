using App.ContaCorrente.Application.CQRS.Emprestimos.Commands;
using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.Servicos
{
    public class EmprestimoServico : IEmprestimoServico
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public EmprestimoServico(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        public Task<EmprestimoDTO> AlterarAsync(EmprestimoDTO emprestimoDto)
        {
            throw new NotImplementedException();
        }

        public async Task<EmprestimoDTO> CriarAsync(EmprestimoDTO emprestimoDto)
        {
            var emprestimoCriarCommand = _mapper.Map<EmprestimoCriarCommand>(emprestimoDto);
            var result = await _mediator.Send(emprestimoCriarCommand);
            var emprestimo = _mapper.Map<EmprestimoDTO>(result);

            return emprestimo;
        }

        public Task<IEnumerable<EmprestimoDTO>> GetPeloCorrentistaIdAsync(int? id)
        {
            throw new NotImplementedException();
        }

        public Task<EmprestimoDTO> GetPeloIdAsync(int? id)
        {
            throw new NotImplementedException();
        }
    }
}
