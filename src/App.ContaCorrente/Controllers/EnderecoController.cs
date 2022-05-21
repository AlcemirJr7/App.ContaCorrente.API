using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization.Json;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoServico _enderecoServico;
        public EnderecoController(IEnderecoServico enderecoServico)
        {
            _enderecoServico = enderecoServico;
        }


        [HttpGet("{id:int}", Name = "GetEndereco")]
        public async Task<ActionResult<EnderecoDTO>> GetEndereco(int? id)             
        {
                        
            var endereco = await _enderecoServico.GetPeloIdAsync(id.Value);

            if (endereco == null) return NotFound($"Endereço não encontrado.");

            return Ok(endereco);

        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> PostEndereco([FromBody] EnderecoDTO enderecoDto)
        {
            if (enderecoDto == null) return BadRequest(Mensagens.DataInvalida);

            try
            {
                await _enderecoServico.CriarAsync(enderecoDto);
            }
            catch (DomainExcepitonValidacao e)
            {                
                return BadRequest(e.Message);                                
            }
                                                                                                
            return new CreatedAtRouteResult("GetEndereco", new { id = enderecoDto.Id }, enderecoDto);

        }
    }
}
