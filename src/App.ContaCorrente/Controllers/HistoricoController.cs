using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class HistoricoController : ControllerBase
    {
        private readonly IHistoricoServico _historicoServico;
        public HistoricoController(IHistoricoServico historicoServico)
        {
            _historicoServico = historicoServico;
        }

        /// <summary>
        /// Cria um novo histótico
        /// </summary>      
        /// <remarks>
        ///  TipoDebidoCredito:  1 - Debito | 2 - Credito
        /// </remarks>
        /// <param name="historicoDto"> Dados para cadastro do histórico </param>
        [HttpPost]        
        public async Task<ActionResult> PostHistorico([FromBody] HistoricoDTO historicoDto)
        {
            if (historicoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            var historico = new object();

            try
            {
                historico = await _historicoServico.CriarAsync(historicoDto);
            }
            catch (DomainException e)
            {                
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {                
                return BadRequest(new { mensagem = e.Message });                
            }
            
            return Ok(historico);
        }

        /// <summary>
        /// Atualiza um histórico pelo id      
        /// </summary>     
        [HttpPut("{id:int}")]       
        public async Task<ActionResult> PutHistorico(int? id,[FromBody] HistoricoDTO historicoDto)
        {
            if (historicoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            
            var historico = new object();
            
            try
            {
                historicoDto.Id = id.Value;
                historico = await _historicoServico.AlterarAsync(historicoDto);
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(historico);
        }

        /// <summary>
        /// Busca um histórico pelo Id    
        /// </summary> 
        [HttpGet("{id:int}")]        
        public async Task<ActionResult<HistoricoDTO>> GetHistorico(int? id)
        {
            if(id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            var hisrotico = new object();
            try
            {
                hisrotico = await _historicoServico.GetPeloIdAsync(id);

                if (hisrotico == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });
            
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(hisrotico);
        }

        /// <summary>
        /// Busca uma lista de históricos
        /// </summary> 
   
        [HttpGet]        
        public async Task<ActionResult<IEnumerable<HistoricoDTO>>> GetHistoricos()
        {            
            var hisrotico = new object();
            try
            {
                hisrotico = await _historicoServico.GetHistoricosAsync();

                if (hisrotico == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada });

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(hisrotico);
        }




    }
}
