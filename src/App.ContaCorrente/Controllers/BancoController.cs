﻿using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Mvc;


namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]    
    [ApiController]
    [Produces("application/json")]
    public class BancoController : ControllerBase
    {
        private readonly IBancoServico _bancoServico;
        public BancoController(IBancoServico bancoServico)
        {
            _bancoServico = bancoServico;
        }
        /// <summary>
        /// busca um lista de bacos
        /// </summary>
        [HttpGet]        
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
        /// <summary>
        /// busca um banco pelo Id
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<BancoDTO>> GetBanco(int? id)
        {
            var banco = new object();   
            try
            {
                banco = await _bancoServico.GetBancoPeloIdAsync(id.Value);

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
        /// <summary>
        /// Cria um novo banco
        /// </summary>
        [HttpPost]        
        public async Task<ActionResult<BancoDTO>> PostBanco([FromBody] BancoDTO bancoDto)
        {
            if (bancoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            BancoDTO? banco = null;
            try
            {
                banco = await _bancoServico.CriarAsync(bancoDto);                
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

        /// <summary>
        /// Atualiza um banco pelo Id
        /// </summary>
        [HttpPut]        
        public async Task<ActionResult<BancoDTO>> PutBanco(int? id,[FromBody] BancoDTO bancoDto)
        {
            if(id != bancoDto.Id) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            BancoDTO? banco = null;

            if (bancoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            try
            {
                banco = await _bancoServico.AlterarAsync(bancoDto);                
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

    }
}
