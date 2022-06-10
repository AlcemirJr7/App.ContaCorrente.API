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
        /// Fazer um agendamento transferencia Pix interno
        /// </summary>        
        /// <param name="transferenciaInternaPixAgendaDto"> Dados para efetuar o agendamento Pix interno </param>
        [HttpPost("Agendamento/Interna/Pix")]
        public async Task<ActionResult<TransferenciaInternaPixAgendaDTO>> PostAgendamentoTransferenciaInternaPix([FromBody] 
                                                                                                                 TransferenciaInternaPixAgendaDTO 
                                                                                                                 transferenciaInternaPixAgendaDto)
        {
            if (transferenciaInternaPixAgendaDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                transferenciaInternaPixAgendaDto = await _transferenciaServico.CriarPixInternoAgendamentoAsync(transferenciaInternaPixAgendaDto);
                transferenciaInternaPixAgendaDto.Mensagem = "Agendametno Pix Realizada com Sucesso!";


                await tr.CommitAsync();

                return Ok(transferenciaInternaPixAgendaDto);

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
        /// <param name="transferenciaExternaEnvaPixDto"> Dados para efetuar a transferencia Pix externa </param>
        [HttpPost("Externo/Pix")]
        public async Task<ActionResult<TransferenciaExternaEnviaPixDTO>> PostTransferenciaExternaPix([FromBody] TransferenciaExternaEnviaPixDTO transferenciaExternaEnvaPixDto)
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

        /// <summary>
        /// Fazer uma transferencia Ted externa
        /// </summary>        
        /// <param name="transferenciaExternaEnviaTedDto"> Dados para efetuar a transferencia Ted externa </param>
        [HttpPost("Externo/Ted")]
        public async Task<ActionResult<TransferenciaExternaEnviaTedDTO>> PostTransferenciaExternaTed([FromBody] TransferenciaExternaEnviaTedDTO transferenciaExternaEnviaTedDto)
        {
            if (transferenciaExternaEnviaTedDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                transferenciaExternaEnviaTedDto = await _transferenciaServico.CriarTedExternoEnvioAsync(transferenciaExternaEnviaTedDto);
                transferenciaExternaEnviaTedDto.Mensagem = "Transferencia Ted Realizada com Sucesso!";


                await tr.CommitAsync();

                return Ok(transferenciaExternaEnviaTedDto);

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
