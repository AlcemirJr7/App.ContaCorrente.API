using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Mvc;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EnderecoController : ControllerBase
    {
        private readonly IEnderecoServico _enderecoServico;
        public EnderecoController(IEnderecoServico enderecoServico)
        {
            _enderecoServico = enderecoServico;
        }

        /// <summary>
        /// Busca o endereço pelo Id
        /// </summary>
        [HttpGet("{id:int}")]        
        public async Task<ActionResult<EnderecoDTO>> GetEndereco(int? id)
        {
            EnderecoDTO? endereco = null;

            try
            {
                endereco = await _enderecoServico.GetPeloIdAsync(id.Value);

                if (endereco == null) return NotFound(new { mensagem = "Endereço não encontrado."});
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
                        
            return Ok(endereco);

        }

        /// <summary>
        /// Criar um novo endereço
        /// </summary>
        [HttpPost]        
        public async Task<ActionResult<EnderecoDTO>> PostEndereco([FromBody] EnderecoDTO enderecoDto)
        {
            if (enderecoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            EnderecoDTO? endereco = null;
            
            try
            {
                endereco = await _enderecoServico.CriarAsync(enderecoDto);
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(endereco);

        }

        /// <summary>
        /// Atualiza um endereço pelo Id
        /// </summary>       
        [HttpPut("{id:int}")]        
        public async Task<ActionResult<EnderecoDTO>> PutEndereco(int? id,[FromBody] EnderecoDTO enderecoDto)
        {
            if (enderecoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            EnderecoDTO? endereco = null;
            
            try
            {                
                endereco = await _enderecoServico.AlterarAsync(enderecoDto);
                
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            return Ok(endereco);
        }

        /// <summary>
        /// Deleta um endereço pelo Id
        /// </summary> 
        /// 
        [HttpDelete("{id:int}")]        
        public async Task<ActionResult<EnderecoDTO>> DeleteEndereco(int? id)
        {            
         
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            var enderecoDto = await _enderecoServico.GetPeloIdAsync(id);
            
            if (enderecoDto == null)
            {
                return BadRequest(new { mensagem = Mensagens.EntidadeNaoEncontrada });
            }

            EnderecoDTO? endereco = null;

            try
            {                
                endereco = await _enderecoServico.DeletarAsync(id);                
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(endereco);
        }
    }
}
