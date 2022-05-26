using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Mvc;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelasEmprestimoController : ControllerBase
    {
        private readonly IParcelasEmprestimoServico _parcelasEmprestimoServico;
        public ParcelasEmprestimoController(IParcelasEmprestimoServico parcelasEmprestimoServico)
        {
            _parcelasEmprestimoServico = parcelasEmprestimoServico;
        }

        /// <summary>
        /// Busca as parcelas pelo emprestimo Id
        /// </summary> 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ParcelasEmprestimoDTO>>> GetParcelasEmprestimo(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            IEnumerable<ParcelasEmprestimoDTO> parcelas = new List<ParcelasEmprestimoDTO>();
            try
            {
                 parcelas = await _parcelasEmprestimoServico.GetPeloEmprestimoIdAsync(id);
                 
                if (parcelas == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(parcelas);
        }
    }
}
