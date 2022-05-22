using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    public class BancoController : ControllerBase
    {
        private readonly IBancoServico _bancoServico;
        public BancoController(IBancoServico bancoServico)
        {
            _bancoServico = bancoServico;
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<IEnumerable<BancoDTO>>> GetBancos()
        {
            var bancos = new object();
            try
            {
                bancos = await _bancoServico.GetBancosAsync();

                if (bancos == null) return NotFound(new { mensagem = "Bancos não encontrados."});
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
         

            return Ok(bancos);

        }

        [HttpGet("{codigo:int}",Name = "GetBanco")]
        [Produces("application/json")]
        public async Task<ActionResult<BancoDTO>> GetBanco(int? codigo)
        {
            var banco = new object();   

            try
            {
                banco = await _bancoServico.GetBancoPeloIdAsync(codigo.Value);

                if (banco == null) return NotFound(new { mensagem = "Banco não encontrados." });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            
            return Ok(banco);

        }

        [HttpPost]
        [Produces("application/json")]
        public async Task<ActionResult> PostBanco([FromBody] BancoDTO bancoDto)
        {
            if (bancoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            try
            {
                await _bancoServico.CriarAsync(bancoDto);
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            

            return new CreatedAtRouteResult("GetBanco", new { codigo = bancoDto.Id }, bancoDto);
        }
        
        [HttpPut]
        [Produces("application/json")]
        public async Task<ActionResult<BancoDTO>> PutBanco(int? id,[FromBody] BancoDTO bancoDto)
        {
            if(id != bancoDto.Id) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            if (bancoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            try
            {
                await _bancoServico.AlterarAsync(bancoDto);
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(bancoDto);
        }

    }
}
