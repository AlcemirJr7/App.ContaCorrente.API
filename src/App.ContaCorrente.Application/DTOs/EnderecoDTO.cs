using App.ContaCorrente.Domain.Utils;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class EnderecoDTO 
    {                
        public int Id { get; set; }                                        

        public string Cep { get; set; }

        public string NomeRua { get;  set; }
        
        public int NumeroRua { get;  set; }

        public string? Complemento { get;  set; }
       
        public string Bairro { get;  set; }
        
        public string Cidade { get;  set; }

        public string Estado { get;  set; }

        public string Sigla { get;  set; }
        
    }
}
