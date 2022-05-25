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

    public class LancamentoFuturoController : ControllerBase
    {
        private readonly ILancamentoFuturoServico _lancamentoFuturoServico;
        public LancamentoFuturoController(ILancamentoFuturoServico lancamentoFuturoServico)
        {
            _lancamentoFuturoServico = lancamentoFuturoServico;
        }

        /// <summary>
        /// Cria um Lancamento Futuro
        /// </summary>              
        /// <param name="lancamentoFuturoDto"> Dados para cadastro do Lancamento Futuro</param>
        [HttpPost]
        public async Task<ActionResult<LancamentoFuturoDTO>> PostLancamentoFuturo([FromBody] LancamentoFuturoDTO lancamentoFuturoDto)
        {
            if (lancamentoFuturoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });            

            try
            {
                lancamentoFuturoDto = await _lancamentoFuturoServico.CriarAsync(lancamentoFuturoDto);
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(lancamentoFuturoDto);
        }
    }
}
