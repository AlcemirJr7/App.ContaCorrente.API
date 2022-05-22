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
    public class LocalTrabalhoController : ControllerBase
    {
        private readonly ILocalTrabalhoServico _localTrabalhoServico;
        public LocalTrabalhoController(ILocalTrabalhoServico localTrabalhoServico)
        {
            _localTrabalhoServico = localTrabalhoServico;
        }

        /// <summary>
        /// Cria um novo Local de trabalho do correntista
        /// </summary>      
        /// <param name="localTrabalhoDto">Dados Local de Trabalho</param>
        [HttpPost]
        public async Task<ActionResult<LocalTrabalhoDTO>> PostLocalTrabalho([FromBody] LocalTrabalhoDTO localTrabalhoDto)
        {
            if (localTrabalhoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            try
            {
                await _localTrabalhoServico.CriarAsync(localTrabalhoDto);
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(localTrabalhoDto);  //new CreatedAtRouteResult("GetBanco", new { codigo = bancoDto.Id }, bancoDto);
        }
    }
}
