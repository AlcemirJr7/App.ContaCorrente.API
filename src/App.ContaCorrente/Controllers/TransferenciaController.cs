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
    public class TransferenciaController : ControllerBase
    {
        private readonly ITransferenciaServico _transferenciaServico;
        private readonly AppDbContexto _appDbContexto;
        public TransferenciaController(ITransferenciaServico transferenciaServico, AppDbContexto appDbContexto)
        {
            _transferenciaServico = transferenciaServico;
            _appDbContexto = appDbContexto;
        }

        /// <summary>
        /// Fazer uma transferencia Pix entre contas internas
        /// </summary>        
        /// <param name="transferenciaInternaPixDto"> Dados para efetuar a transferencia Pix </param>
        [HttpPost("Interna/Pix")]
        public async Task<ActionResult<TransferenciaInternaPixDTO>> PostTransferenciaInterna([FromBody] TransferenciaInternaPixDTO transferenciaInternaPixDto)
        {
            if (transferenciaInternaPixDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            
            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                transferenciaInternaPixDto = await _transferenciaServico.CriarPixAsync(transferenciaInternaPixDto);
                transferenciaInternaPixDto.Mensagen = "Transferencia Pix Realizada com Sucesso!";


                await tr.CommitAsync();

                return Ok(transferenciaInternaPixDto);

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

    }
}
