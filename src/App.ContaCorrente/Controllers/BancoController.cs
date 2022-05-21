using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
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
        public async Task<ActionResult<IEnumerable<BancoDTO>>> GetBancos()
        {
            var bancos = await _bancoServico.GetBancosAsync();

            if (bancos == null) return NotFound("Bancos não encontrados.");

            return Ok(bancos);

        }

        [HttpGet("{codigo:int}",Name = "GetBanco")]
        public async Task<ActionResult<BancoDTO>> GetBanco(int? codigo)
        {
            var banco = await _bancoServico.GetBancoPeloIdAsync(codigo.Value);

            if (banco == null) return NotFound("Banco não encontrado.");

            return Ok(banco);

        }

        [HttpPost]
        public async Task<ActionResult> PostBanco([FromBody] BancoDTO bancoDto)
        {
            if (bancoDto == null) return BadRequest(Mensagens.DataInvalida);
            await _bancoServico.CriarAsync(bancoDto);

            return new CreatedAtRouteResult("GetBanco", new { codigo = bancoDto.Id }, bancoDto);
        }
        
        [HttpPut]
        public async Task<ActionResult<BancoDTO>> PutBanco(int? id,[FromBody] BancoDTO bancoDto)
        {
            if(id != bancoDto.Id) return BadRequest(Mensagens.DataInvalida);

            if (bancoDto == null) return BadRequest(Mensagens.DataInvalida);

            await _bancoServico.AlterarAsync(bancoDto);

            return Ok(bancoDto);
        }

    }
}
