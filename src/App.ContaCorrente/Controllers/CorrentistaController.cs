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
    public class CorrentistaController : ControllerBase
    {
        private readonly ICorrentistaServico _correntistaServico;
        public CorrentistaController(ICorrentistaServico correntistaServico)
        {
            _correntistaServico = correntistaServico;   
        }

        /// <summary>
        /// Cria um novo Correntista
        /// </summary>    
        /// <remarks>
        ///  FlagConta:  1 - EmAnalise | 2 - Aberta | 3 - Fechada              
        /// </remarks>
        /// <param name="correntistaDto">Dados do Correntista </param>        
        [HttpPost]
        public async Task<ActionResult> PostCorrentista([FromBody] CorrentistaDTO correntistaDto)
        {
            if (correntistaDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            var correntista = new object();
            try
            {
                correntista = await _correntistaServico.CriarAsync(correntistaDto);
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(correntista);
        }
    }
}
