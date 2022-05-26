using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
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
    public class LocalTrabalhoController : ControllerBase
    {
        private readonly ILocalTrabalhoServico _localTrabalhoServico;
        private readonly AppDbContexto _appDbContexto;
        public LocalTrabalhoController(ILocalTrabalhoServico localTrabalhoServico, AppDbContexto appDbContexto)
        {
            _localTrabalhoServico = localTrabalhoServico;
            _appDbContexto = appDbContexto; 
        }

        /// <summary>
        /// Cria um novo Local de trabalho do correntista
        /// </summary>      
        /// <param name="localTrabalhoDto">Dados Local de Trabalho</param>
        [HttpPost]
        public async Task<ActionResult<LocalTrabalhoDTO>> PostLocalTrabalho([FromBody] LocalTrabalhoDTO localTrabalhoDto)
        {
            if (localTrabalhoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            LocalTrabalhoDTO? localTrabalho = null;

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                localTrabalho = await _localTrabalhoServico.CriarAsync(localTrabalhoDto);
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

            return Ok(localTrabalho); 
        }

        /// <summary>
        /// Atualiza um Local de Trabalho    
        /// </summary>     
        [HttpPut("{id:int}")]
        public async Task<ActionResult<LocalTrabalhoDTO>> PutLocalTrabalho(int? id, [FromBody] LocalTrabalhoDTO localTrabalhoDto)
        {
            if (localTrabalhoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            LocalTrabalhoDTO? localTrabalho = null;

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {                
                localTrabalho = await _localTrabalhoServico.AlterarAsync(localTrabalhoDto);
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

            return Ok(localTrabalho);
        }

        /// <summary>
        /// Busca um Local de Trabalho
        /// </summary> 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<LocalTrabalhoDTO>> GetLocalTrabalho(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            LocalTrabalhoDTO? localTrabalho = null;

            try
            {
                localTrabalho = await _localTrabalhoServico.GetPeloIdAsync(id);

                if (localTrabalho == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(localTrabalho);
        }


    }
}
