using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HistoricoController : ControllerBase
    {
        private readonly IHistoricoServico _historicoServico;
        public HistoricoController(IHistoricoServico historicoServico)
        {
            _historicoServico = historicoServico;
        }
        
        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult<HistoricoDTO>> PostHistorico([FromBody] HistoricoDTO historicoDto)
        {
            if (historicoDto == null) return BadRequest(new { erro = Mensagens.DataInvalida });

            try
            {
                await _historicoServico.CriarAsync(historicoDto);
            }
            catch (DomainException e)
            {                
                return BadRequest(new { erro = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {                
                return BadRequest(new { erro = e.Message });                
            }
            
            return Ok(historicoDto);  //new CreatedAtRouteResult("GetBanco", new { codigo = bancoDto.Id }, bancoDto);
        }

    }
}
