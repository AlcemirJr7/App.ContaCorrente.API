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
        
        public string Nome { get; set; }
        
        public string NomeCompleto { get; set; }
    }
}
