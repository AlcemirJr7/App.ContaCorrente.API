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
    public class SaldoContaCorrenteController : ControllerBase
    {
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;
        public SaldoContaCorrenteController(ISaldoContaCorrenteServico saldoContaCorrenteServico)
        {
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
        }

        /// <summary>
        /// Busca o saldo pelo Id do correntista
        /// </summary> 
        [HttpGet("Correntista/{id:int}")]
        public async Task<ActionResult<SaldoContaCorrenteDTO>> GetSaldoCorrentista(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            var saldo = new object();

            try
            {
                saldo = await _saldoContaCorrenteServico.GetPeloCorrentistaIdAsync(id);

                if (saldo == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(saldo);
        }

        /// <summary>
        /// Busca o saldo pelo Id
        /// </summary> 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<SaldoContaCorrenteDTO>> GetSaldo(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            var saldo = new object();

            try
            {
                saldo = await _saldoContaCorrenteServico.GetPeloIdAsync(id);

                if (saldo == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(saldo);
        }
    }
}
