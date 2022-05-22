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
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaServico _pessoaServico;
        public PessoaController(IPessoaServico pessoaServico)
        {
            _pessoaServico = pessoaServico;
        }

        /// <summary>
        /// Cria um nova Pessoa
        /// </summary>    
        /// <remarks>
        ///  TipoPessoa:  1 - Pessoa Física | 2 - Pessoa Jurídica               
        /// </remarks>
        /// <param name="pessoaDto">Dados da Pessoa </param>        
        [HttpPost]
        public async Task<ActionResult<PessoaDTO>> PostPessoa([FromBody] PessoaDTO pessoaDto)
        {
            if (pessoaDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            try
            {
                await _pessoaServico.CriarAsync(pessoaDto);
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(pessoaDto);  //new CreatedAtRouteResult("GetBanco", new { codigo = bancoDto.Id }, bancoDto);
        }
    }
}
