using App.ContaCorrente.Application.DTOs;
using App.ContaCorrente.Application.Servicos.Interfaces;
using App.ContaCorrente.Domain.Mensagem;
using App.ContaCorrente.Domain.Validacoes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace App.ContaCorrente.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoServico _emprestimoServico;
        public EmprestimoController(IEmprestimoServico emprestimoServico)
        {
            _emprestimoServico = emprestimoServico;
        }

        /// <summary>
        /// Cria um novo Emprestimo (Proposta)
        /// </summary>
        /// <remarks>
        ///  TipoFinalidade:  1 - Pagar Dividas | 2 - Construir | 3 - Comprar Carro | 4 - Viajar | 5 - Despesas Medicas | 6 - Outros  
        ///  
        ///  TipoEmprestimo:  1 - Financiamento | 2 - Emprestimo Pessoal | 3 - Emprestimo Cheque Especial
        /// </remarks>        
        /// <param name="emprestimoDto"> Dados para cadastrar uma proposta de emprestimo </param>
        [HttpPost]
        public async Task<ActionResult<EmprestimoDTO>> PostEmprestimo([FromBody] EmprestimoDTO emprestimoDto)
        {
            if (emprestimoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            
            try
            {
                emprestimoDto = await _emprestimoServico.CriarAsync(emprestimoDto);
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(emprestimoDto);
        }


    }
}
