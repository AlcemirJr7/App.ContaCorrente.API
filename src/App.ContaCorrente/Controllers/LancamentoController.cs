using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoServico _lancamentoServico;
        public LancamentoController(ILancamentoServico lancamentoServico)
        {
            _lancamentoServico = lancamentoServico;
        }

        /// <summary>
        /// Cria um lançamento na conta corrente
        /// </summary>      
        /// <param name="lancamentoDto">Dados do Lançamento</param>
        [HttpPost]
        public async Task<ActionResult<LancamentoDTO>> PostHistorico([FromBody] LancamentoDTO lancamentoDto)
        {
            if (lancamentoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
                        
            try
            {
                var lancamento = await _lancamentoServico.CriarAsync(lancamentoDto);
                lancamentoDto.Id = lancamento.Id;
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }            

            return Ok(lancamentoDto);
        }
    }
}
