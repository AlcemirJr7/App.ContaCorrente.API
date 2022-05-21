using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.DTOs
{
    public class BancoDTO
    {
        [JsonPropertyName("codigo")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome é obrigatorio.")]                
        public string Nome { get; set; }

        [Required(ErrorMessage = "Nome Completo é obrigatorio.")]        
        public string NomeCompleto { get; set; }
    }
}
