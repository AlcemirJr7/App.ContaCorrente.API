using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LancamentoController : ControllerBase
    {
        private readonly ILancamentoServico _lancamentoServico;      
        private readonly AppDbContexto _appDbContexto;
        public LancamentoController(ILancamentoServico lancamentoServico, AppDbContexto appDbContexto)
        {
            _lancamentoServico = lancamentoServico;                        
            _appDbContexto = appDbContexto;
        }

        /// <summary>
        /// Cria um lançamento na conta corrente
        /// </summary>      
        /// <param name="lancamentoDto">Dados do Lançamento</param>
        [HttpPost]
        public async Task<ActionResult<LancamentoDTO>> PostLancamento([FromBody] LancamentoDTO lancamentoDto)
        {
            if (lancamentoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
                   
            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                
                lancamentoDto = await _lancamentoServico.CriarAsync(lancamentoDto);
                                                
            }
            catch (DomainException e)
            {
                await tr.RollbackAsync();
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                await tr.RollbackAsync();
                return BadRequest(new { mensagem = e.Message });
            }

            await tr.CommitAsync();

            return Ok(lancamentoDto);
        }

        /// <summary>
        /// Busca um lançamento pelo Id
        /// </summary> 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LancamentoDTO>> GetLancamento(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            LancamentoDTO lancamento = new LancamentoDTO();

            try
            {
                lancamento = await _lancamentoServico.GetPeloIdAsync(id);

                if (lancamento == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(lancamento);
        }

        /// <summary>
        /// Busca um lançamento pelo Id do correntista
        /// </summary> 
        [HttpGet("Correntista/{id:int}")]
        public async Task<ActionResult<IEnumerable<LancamentoDTO>>> GetLancamentos(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            IEnumerable<LancamentoDTO> lancamento = new List<LancamentoDTO>();

            try
            {
                lancamento = await _lancamentoServico.GetPeloCorrentistaIdAsync(id);

                if (lancamento == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(lancamento);
        }
    }
}
