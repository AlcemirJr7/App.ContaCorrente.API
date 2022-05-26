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
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoServico _pagamentoServico;  
        private readonly AppDbContexto _appDbContexto;
        public PagamentoController(IPagamentoServico pagamentoServico, AppDbContexto appDbContexto)
        {
            _pagamentoServico = pagamentoServico;                      
            _appDbContexto = appDbContexto;
        }


        /// <summary>
        /// Efetuar um Pagamento
        /// </summary>      
        /// <param name="pagamentoDto">Dados do Pagamento</param>
        [HttpPost]
        public async Task<ActionResult<PagamentoDTO>> PostPagamento([FromBody] PagamentoDTO pagamentoDto)
        {
            if (pagamentoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();
            try
            {                
                //Cria o pagamento
                pagamentoDto = await _pagamentoServico.CriarAsync(pagamentoDto);
                pagamentoDto.Mensagen = Mensagens.PagamentoRealizadoSucesso;
                                
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

            return Ok(pagamentoDto);
        }

        /// <summary>
        /// Cria um pagamento agendado
        /// </summary>      
        /// <param name="pagamentoDto">Dados do Pagamento</param>
        [HttpPost("Agendamento/")]
        public async Task<ActionResult<PagamentoAgendaDTO>> PostAgendamentoPagamento([FromBody] PagamentoAgendaDTO pagamentoDto)
        {
            if (pagamentoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();
            try
            {
                //Cria o pagamento
                pagamentoDto = await _pagamentoServico.CriarAgendamentoAsync(pagamentoDto);
                pagamentoDto.Mensagen = Mensagens.AgendamentoPagamentoSucesso;

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

            return Ok(pagamentoDto);
        }

        /// <summary>
        /// Busca um Pagamento pelo Id
        /// </summary> 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PagamentoDTO>> GetPagamento(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            PagamentoDTO pagamentoDto = new PagamentoDTO();

            try
            {
                pagamentoDto = await _pagamentoServico.GetPeloIdAsync(id);

                if (pagamentoDto == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(pagamentoDto);
        }

        /// <summary>
        /// Busca Pagamentos pelo Id do Correntista
        /// </summary> 
        [HttpGet("Correntista/{id:int}")]
        public async Task<ActionResult<IEnumerable<PagamentoDTO>>> GetPagamentos(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            IEnumerable<PagamentoDTO> pagamentosDto = new List<PagamentoDTO>();

            try
            {
                pagamentosDto = await _pagamentoServico.GetPeloCorrentistaIdAsync(id);

                if (pagamentosDto == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(pagamentosDto);
        }
    }
}
