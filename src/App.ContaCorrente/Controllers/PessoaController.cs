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
    public class PessoaController : ControllerBase
    {
        private readonly IPessoaServico _pessoaServico;
        private readonly AppDbContexto _appDbContexto;
        public PessoaController(IPessoaServico pessoaServico, AppDbContexto appDbContexto)
        {
            _pessoaServico = pessoaServico;
            _appDbContexto = appDbContexto;
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

            PessoaDTO? pessoa = null;

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                pessoa = await _pessoaServico.CriarAsync(pessoaDto);
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

            return Ok(pessoa); 
        }

        /// <summary>
        /// Altera o cadastr da Pessoa
        /// </summary>    
        /// <remarks>
        ///  TipoPessoa:  1 - Pessoa Física | 2 - Pessoa Jurídica               
        /// </remarks>
        /// <param name="pessoaDto">Dados da Pessoa </param>        
        [HttpPut("{id:int}")]
        public async Task<ActionResult<PessoaDTO>> PutPessoa(int? id,[FromBody] PessoaDTO pessoaDto)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            if (pessoaDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            PessoaDTO? pessoa = null;

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {                
                pessoa = await _pessoaServico.AlterarAsync(pessoaDto);
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

            return Ok(pessoa);
        }

        /// <summary>
        /// Busca uma Pessoa pelo Id
        /// </summary> 
        [HttpGet("{id:int}")]
        public async Task<ActionResult<PessoaDTO>> GetPessoa(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            var pessoa = new object();

            try
            {
                pessoa = await _pessoaServico.GetPeloIdAsync(id);

                if (pessoa == null) return NotFound(new { mensagem = Mensagens.EntidadeNaoEncontrada});

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

            return Ok(pessoa);
        }
    }
}
