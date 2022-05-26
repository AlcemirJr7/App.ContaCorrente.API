using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
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
    public class CorrentistaController : ControllerBase
    {
        private readonly ICorrentistaServico _correntistaServico;
        private readonly AppDbContexto _appDbContexto;
        public CorrentistaController(ICorrentistaServico correntistaServico, AppDbContexto appDbContexto)
        {
            _correntistaServico = correntistaServico;
            _appDbContexto = appDbContexto; 
        }

        /// <summary>
        /// Cria um novo Correntista
        /// </summary>            
        /// <param name="correntistaDto">Dados do Correntista</param>        
        [HttpPost]
        public async Task<ActionResult<Correntista>> PostCorrentista([FromBody] CorrentistaDTO correntistaDto)
        {
            if (correntistaDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            Correntista? correntista = null;

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();   
            try
            {
                correntista = await _correntistaServico.CriarAsync(correntistaDto);
                
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

            return Ok(correntista);
        }

        /// <summary>
        /// Atualiza um Correntista
        /// </summary>       
        [HttpPut("{id:int}")]
        public async Task<ActionResult<CorrentistaAlteraDTO>> PutCorrentista(int? id, [FromBody] CorrentistaAlteraDTO correntistaAlteraDto)
        {
            if (correntistaAlteraDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            CorrentistaAlteraDTO correntista = new CorrentistaAlteraDTO();

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                correntistaAlteraDto.Id = id.Value;
                correntista = await _correntistaServico.AlterarAsync(correntistaAlteraDto);                
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

            return Ok(correntista);
        }

        /// <summary>
        /// Busca um Correntista pelo Id
        /// </summary> 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<Correntista>> GetCorrentista(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            Correntista? correntista = null;

            try
            {
                correntista = await _correntistaServico.GetPeloIdAsync(id);                

                if (correntista == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(correntista);
        }

    }
}
