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
        public async Task<ActionResult<TransferenciaInternaPixDTO>> PostTransferenciaInternaPix([FromBody] TransferenciaInternaPixDTO transferenciaInternaPixDto)
        {
            if (transferenciaInternaPixDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            
            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                transferenciaInternaPixDto = await _transferenciaServico.CriarPixInternoAsync(transferenciaInternaPixDto);
                transferenciaInternaPixDto.Mensagem = "Transferencia Pix Realizada com Sucesso!";


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


        /// <summary>
        /// Fazer uma transferencia Ted entre contas internas
        /// </summary>        
        /// <param name="transferenciaInternaTedDto"> Dados para efetuar a transferencia Ted </param>
        [HttpPost("Interna/Ted")]
        public async Task<ActionResult<TransferenciaInternaTedDTO>> PostTransferenciaInternaTed([FromBody] TransferenciaInternaTedDTO transferenciaInternaTedDto)
        {
            if (transferenciaInternaTedDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                transferenciaInternaTedDto = await _transferenciaServico.CriarTedInternoAsync(transferenciaInternaTedDto);
                transferenciaInternaTedDto.Mensagem = "Transferencia Ted Realizada com Sucesso!";


                await tr.CommitAsync();

                return Ok(transferenciaInternaTedDto);

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
        /// Fazer uma transferencia Pix externa
        /// </summary>        
        /// <param name="transferenciaInternaPixDto"> Dados para efetuar a transferencia Pix </param>
        [HttpPost("Externo/Pix")]
        public async Task<ActionResult<TransferenciaExternaEnvaPixDTO>> PostTransferenciaExternaPix([FromBody] TransferenciaExternaEnvaPixDTO transferenciaExternaEnvaPixDto)
        {
            if (transferenciaExternaEnvaPixDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                transferenciaExternaEnvaPixDto = await _transferenciaServico.CriarPixExternoEnvioAsync(transferenciaExternaEnvaPixDto);
                transferenciaExternaEnvaPixDto.Mensagem = "Transferencia Pix Realizada com Sucesso!";


                await tr.CommitAsync();

                return Ok(transferenciaExternaEnvaPixDto);

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
