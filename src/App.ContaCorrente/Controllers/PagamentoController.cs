using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Enumerador;
using App.ContaCorrente.Domain.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class PagamentoController : ControllerBase
    {
        private readonly IPagamentoServico _pagamentoServico;
        private readonly ISaldoContaCorrenteServico _saldoContaCorrenteServico;
        private readonly ILancamentoServico _lancamentoServico;
        private readonly ILancamentoRepositorio _lancamentoRepositorio;
        private readonly IPagamentoRepositorio _pagamentoRepositorio;
        public PagamentoController(IPagamentoServico pagamentoServico, ISaldoContaCorrenteServico saldoContaCorrenteServico, ILancamentoServico lancamentoServico,
                                   ILancamentoRepositorio lancamentoRepositorio, IPagamentoRepositorio pagamentoRepositorio)
        {
            _pagamentoServico = pagamentoServico;
            _saldoContaCorrenteServico = saldoContaCorrenteServico;
            _lancamentoServico = lancamentoServico;
            _lancamentoRepositorio = lancamentoRepositorio;
        }


        /// <summary>
        /// Efetuar um Pagamento
        /// </summary>      
        /// <param name="pagamentoDto">Dados do Pagamento</param>
        [HttpPost]
        public async Task<ActionResult<PagamentoDTO>> PostPagamento([FromBody] PagamentoDTO pagamentoDto)
        {
            if (pagamentoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            
            try
            {
                //validar saldo 
                await _saldoContaCorrenteServico.ValidaSaldoAsync(pagamentoDto.CorrentistaId,(int)EnumPagamentoHistorico.historico,pagamentoDto.Valor);

                //Cria o pagamento
                pagamentoDto = await _pagamentoServico.CriarAsync(pagamentoDto);

                LancamentoDTO lancamentoDto = new LancamentoDTO
                {
                    CorrentistaId = pagamentoDto.CorrentistaId,
                    Valor = pagamentoDto.Valor,
                    HistoricoId = (int)EnumPagamentoHistorico.historico,
                    Observacao = pagamentoDto.CodigoBarra
                    
                };
                
                try
                {
                    lancamentoDto = await _lancamentoServico.CriarAsync(lancamentoDto);

                    await _saldoContaCorrenteServico.AtulizaSaldoAsync(pagamentoDto.CorrentistaId, (int)EnumPagamentoHistorico.historico, pagamentoDto.Valor);
                }
                catch (DomainException e)
                {
                    
                    try
                    {
                        //desfazer a operação
                        await _lancamentoRepositorio.DeletarAsync(lancamentoDto.Id);
                        await _pagamentoRepositorio.DeletarAsync(pagamentoDto.Id);
                    }
                    catch (DomainException ex)
                    {
                        return BadRequest(new { mensagem = ex.Message + Mensagens.NaoFoiPossivelCompletarOperacao });
                    }
                    
                    return BadRequest(new { mensagem = e.Message + Mensagens.NaoFoiPossivelCompletarOperacao });                    
                }
                
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
