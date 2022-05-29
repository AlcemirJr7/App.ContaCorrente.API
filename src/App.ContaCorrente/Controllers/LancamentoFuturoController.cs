using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.AspNetCore.Mvc;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]

    public class LancamentoFuturoController : ControllerBase
    {
        private readonly ILancamentoFuturoServico _lancamentoFuturoServico;
        private readonly AppDbContexto _appDbContexto;
        public LancamentoFuturoController(ILancamentoFuturoServico lancamentoFuturoServico, AppDbContexto appDbContexto)
        {
            _lancamentoFuturoServico = lancamentoFuturoServico;
            _appDbContexto = appDbContexto; 
        }

        /// <summary>
        /// Cria um Lancamento Futuro
        /// </summary>              
        /// <param name="lancamentoFuturoDto"> Dados para cadastro do Lancamento Futuro</param>
        [HttpPost]
        public async Task<ActionResult<LancamentoFuturoDTO>> PostLancamentoFuturo([FromBody] LancamentoFuturoDTO lancamentoFuturoDto)
        {
            if (lancamentoFuturoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });            

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();
            try
            {
                lancamentoFuturoDto = await _lancamentoFuturoServico.CriarAsync(lancamentoFuturoDto);
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

            return Ok(lancamentoFuturoDto);
        }

        /// <summary>
        /// Efetivar lançamentos futuros
        /// </summary>                     
        [HttpPost("Efetivar/")]
        public async Task<ActionResult<IEnumerable<LancamentoFuturoDTO>>> PostEfetivarLancamentosFuturos()
        {
            
            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            IEnumerable<LancamentoFuturoDTO> lancamentosFuturos = new List<LancamentoFuturoDTO>();
            try
            {
                lancamentosFuturos = await _lancamentoFuturoServico.ProcessaLancamentosFuturos();
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

            return Ok(lancamentosFuturos);
        }

        /// <summary>
        /// Cancelar um lançamento futuro pelo Id
        /// </summary>                      
        [HttpPut("Cancelar/{id:int}")]
        public async Task<ActionResult<LancamentoFuturoDTO>> PutCancelarLancamentoFuturo(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();
            try
            {
                var lancamentoFuturo = await _lancamentoFuturoServico.CancelarAsync(id);
                
                await tr.CommitAsync();

                return Ok(lancamentoFuturo);
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
