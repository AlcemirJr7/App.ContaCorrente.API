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
    public class ChavePixController : ControllerBase
    {
        private readonly IChavePixServico _chavePixServco;
        private readonly AppDbContexto _appDbContexto;
        public ChavePixController(IChavePixServico chavePixServco, AppDbContexto appDbContexto)
        {
            _chavePixServco = chavePixServco;
            _appDbContexto = appDbContexto;
        }
        
        /// <summary>
        /// Cria uma Chave Pix para o correntista
        /// </summary>
        /// <remarks>
        ///  TipoChave :  1 - Cpf | 2 - Cnpj | 3 - Email | 4 - Celular | 5 Aleatorio
        /// </remarks>
        /// <param name="chavePixDto">Dados para cadastro da chave pix</param>    
        [HttpPost]
        public async Task<ActionResult<ChavePixDTO>> PostChavePix([FromBody] ChavePixDTO chavePixDto)
        {
            if (chavePixDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            
            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                var chavePix = await _chavePixServco.CriarAsync(chavePixDto);
                
                await tr.CommitAsync();

                return Ok(chavePix);
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
        /// Inativa uma Chave Pix pelo Correntista Id
        /// </summary>
        /// <remarks>
        ///  TipoChave :  1 - Cpf | 2 - Cnpj | 3 - Email | 4 - Celular | 5 Aleatorio
        /// </remarks>
        /// <param name="id">Id do Correntista</param>    
        [HttpPut("Inativar/{id:int}")]
        public async Task<ActionResult<ChavePixDTO>> PutChavePix(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            using var tr = await _appDbContexto.Database.BeginTransactionAsync();

            try
            {
                var chavePixAlterado = await _chavePixServco.AlterarAsync(id);

                await tr.CommitAsync();

                return Ok(chavePixAlterado);
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
        /// Busca chave pix pela chave
        /// </summary>
        /// <remarks>
        ///  TipoChave :  1 - Cpf | 2 - Cnpj | 3 - Email | 4 - Celular | 5 Aleatorio
        /// </remarks>
        /// <param name="chave">Chave do Pix</param>    
        [HttpGet("{chave}")]
        public async Task<ActionResult<ChavePixDTO>> GetChavePixPelaChave(string? chave)
        {
            if (chave == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            
            try
            {
                var chavePix = await _chavePixServco.GetChavePixPelaChaveAsync(chave);

                if(chavePix == null) return NotFound(new { mensagem = Mensagens.ChavePixNaoEncontrada });
            
                return Ok(chavePix);
            }
            catch (DomainException e)
            {            
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {                
                return BadRequest(new { mensagem = e.Message });
            }

        }

        /// <summary>
        /// Busca chave pix pelo Correntista Id
        /// </summary>
        /// <remarks>
        ///  TipoChave :  1 - Cpf | 2 - Cnpj | 3 - Email | 4 - Celular | 5 Aleatorio
        /// </remarks>
        /// <param name="id">id do Correntista</param>    
        [HttpGet("Correntista/{id:int}")]
        public async Task<ActionResult<ChavePixDTO>> GetChavePixPeloCorrerntistaId(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            try
            {
                var chavePix = await _chavePixServco.GetChavePixPeloCorrentistaIdAsync(id);

                if (chavePix == null) return NotFound(new { mensagem = Mensagens.ChavePixNaoEncontrada });

                return Ok(chavePix);
            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }

        }

    }
}
