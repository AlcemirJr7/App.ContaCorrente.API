using App.ContaCorrente.Domain.Enumerador;

namespace App.ContaCorrente.Application.DTOs
{
    public class ChavePixDTO
    {
        public ChavePixDTO()
        {

        }
        public int Id { get; set; }

        public string? Chave { get; set; }
        
        public DateTime DataCadastro { get; set; }

        public DateTime? DataInativacao { get; set; }

        public EnumChavePixTipo TipoChave { get; set; }

        public EnumChavePixSituacao Situacao { get; set; }

        public int CorrentistaId { get; set; }


    }
}
