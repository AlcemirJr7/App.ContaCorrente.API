using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using App.ContaCorrente.Infra.Data.Contexto;
using Microsoft.AspNetCore.Mvc;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class ParcelasEmprestimoController : ControllerBase
    {
        private readonly IParcelasEmprestimoServico _parcelasEmprestimoServico;
        private readonly AppDbContexto _appDbContexto;
        public ParcelasEmprestimoController(IParcelasEmprestimoServico parcelasEmprestimoServico, AppDbContexto appDbContexto)
        {
            _parcelasEmprestimoServico = parcelasEmprestimoServico;
            _appDbContexto = appDbContexto; 
        }

        /// <summary>
        /// Busca as parcelas pelo emprestimo Id
        /// </summary> 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<IEnumerable<ParcelasEmprestimoDTO>>> GetParcelasEmprestimo(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            IEnumerable<ParcelasEmprestimoDTO> parcelas = new List<ParcelasEmprestimoDTO>();
            try
            {
                 parcelas = await _parcelasEmprestimoServico.GetPeloEmprestimoIdAsync(id);
                 
                if (parcelas == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(parcelas);
        }

        /// <summary>
        /// Efetua pagamento de parcelas emprestimos a vencer
        /// </summary> 
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ParcelasEmprestimoDTO>>> PostPagarParcelasEmprestimo()
        {
            
            IEnumerable<ParcelasEmprestimoDTO> parcelas = new List<ParcelasEmprestimoDTO>();

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                parcelas = await _parcelasEmprestimoServico.ProcessaPagamentoParcelasEmprestimoAsync();
                
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

            return Ok(parcelas);
        }


        /// <summary>
        /// Efetua pagamento antecipado de parcelas emprestimo
        /// </summary> 
        [HttpPost("Antecipar/")]
        public async Task<ActionResult<IEnumerable<ParcelasEmprestimoAntecipaDTO>>> PostPagarAntecipadoParcelasEmprestimo([FromBody] IEnumerable<ParcelasEmprestimoAntecipaDTO> parcelasDto)
        {

            var parcelas = new List<ParcelasEmprestimoAntecipaDTO>();

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();
            

            try
            {
                foreach (var parcela in parcelasDto)
                {
                    var parcelaDto = await _parcelasEmprestimoServico.PagamentoAntecipadoParcelaEmprestimoAsync(parcela);
                    parcelas.Add(parcelaDto.First());
                }
                
                foreach (var parcela in parcelas)
                {
                    parcela.mensagem = "Pagamento da parcela Efetuada com Sucesso!";
                }
                        
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

            return Ok(parcelas);
        }
    }
}
