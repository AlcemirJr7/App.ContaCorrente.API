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

        /// <summary>
        /// Busca um Lançamento Futuro pelo Id
        /// </summary> 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LancamentoFuturoDTO>> GetLancamentoFuturo(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            LancamentoFuturoDTO lancamentoFuturoDto = new LancamentoFuturoDTO();
            try
            {
                lancamentoFuturoDto = await _lancamentoFuturoServico.GetPeloIdAsync(id);

                if (lancamentoFuturoDto == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

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

        /// <summary>
        /// Busca Lançamentos Futuros pelo Id do Correntista
        /// </summary> 
        [HttpGet("Correntista/{id:int}")]
        public async Task<ActionResult<IEnumerable<LancamentoFuturoDTO>>> GetLancamentosFuturos(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            IEnumerable<LancamentoFuturoDTO> lancamentoFuturoDto = new List<LancamentoFuturoDTO>();
            try
            {
                lancamentoFuturoDto = await _lancamentoFuturoServico.GetPeloCorrentistaIdAsync(id);

                if (lancamentoFuturoDto == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

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
