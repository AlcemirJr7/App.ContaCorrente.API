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
    public class EmprestimoController : ControllerBase
    {
        private readonly IEmprestimoServico _emprestimoServico;
        private readonly AppDbContexto _appDbContexto;
        public EmprestimoController(IEmprestimoServico emprestimoServico, AppDbContexto appDbContexto)
        {
            _emprestimoServico = emprestimoServico;
            _appDbContexto = appDbContexto; 
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

        public enum EnumFlagEstadoEmprestimo
        {
            Proposta = 1,
            Efetivado = 2

        }

        public enum EnumProcessoEmprestimo
        {
            EmAnalise = 1,
            Rejeitado = 2,
            Aprovado = 3

        }

        /// <summary>
        /// Efetiva um emprestimo pelo Id
        /// </summary>
        /// <remarks>
        ///  
        ///  TipoFinalidade:  1 - Pagar Dividas | 2 - Construir | 3 - Comprar Carro | 4 - Viajar | 5 - Despesas Medicas | 6 - Outros  
        ///  
        ///  TipoEmprestimo:  1 - Financiamento | 2 - Emprestimo Pessoal | 3 - Emprestimo Cheque Especial
        ///  
        ///  FlagEstado: 1 - Proposta | 2 Efetivado
        ///  
        ///  FlagProcesso: 1 - Em Analise | 2 - Rejeitado | 3 - Aprovado
        ///  
        /// </remarks>        
        /// <param name="id"> Id do emprestimo </param>       
        [HttpPost("Efetiva/{id:int}")]
        public async Task<ActionResult<EmprestimoEfetivarDTO>> PostEfetivaEmprestimo(int? id)
        {
            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            EmprestimoEfetivarDTO emprestimoEfetivarDto = new EmprestimoEfetivarDTO();

            using var tr = await _appDbContexto.Database.BeginTransactionAsync(); 

            try
            {
                emprestimoEfetivarDto = await _emprestimoServico.EfetivarEmprestimoAsync(id);
                emprestimoEfetivarDto.Mensagem = Mensagens.EmprestimoEfetivadoSucesso;
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

            return Ok(emprestimoEfetivarDto);
        }

        /// <summary>
        /// Busca um emprestimo pelo Id
        /// </summary>
        [HttpGet("{id:int}")]
        public async Task<ActionResult<EmprestimoDTO>> GetEmprestimo(int? id)
        {

            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            EmprestimoDTO emprestimoDto = new EmprestimoDTO();

            try
            {
                emprestimoDto = await _emprestimoServico.GetPeloIdAsync(id.Value);

                if (emprestimoDto == null) return NotFound(new { mensagem = "Emprestimo não encontrado." });

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

        /// <summary>
        /// Busca um emprestimo pelo Id do correntista
        /// </summary>
        [HttpGet("Correntista/{id:int}")]
        public async Task<ActionResult<IEnumerable<EmprestimoDTO>>> GetEmprestimos(int? id)
        {
            if(id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            IEnumerable<EmprestimoDTO> emprestimoDto = new List<EmprestimoDTO>();

            try
            {
                emprestimoDto = await _emprestimoServico.GetPeloCorrentistaIdAsync(id.Value);

                if (emprestimoDto.Count() == 0) return NotFound(new { mensagem = "Emprestimos não encontrado." });

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

        /// <summary>
        /// Atualiza um emprestimo pelo Id
        /// </summary>       
        [HttpPut("{id:int}")]
        public async Task<ActionResult<EmprestimoDTO>> PutEmprestimo(int? id, [FromBody] EmprestimoDTO enderecoDto)
        {
            if (enderecoDto == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });

            if (id == null) return BadRequest(new { mensagem = Mensagens.DataInvalida });
            
            try
            {
                enderecoDto = await _emprestimoServico.AlterarAsync(enderecoDto);

            }
            catch (DomainException e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            catch (DomainExcepitonValidacao e)
            {
                return BadRequest(new { mensagem = e.Message });
            }
            return Ok(enderecoDto);
        }


    }
}
