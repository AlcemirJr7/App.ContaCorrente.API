using App.ContaCorrente.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace App.ContaCorrente.Application.DTOs
{
    public class EnderecoDTO 
    {
        [JsonIgnore]
        public int Id { get; set; }

        [Required(ErrorMessage = "CEP é obrigatorio.")]        
        public int Cep { get;  set; }

        [Required(ErrorMessage = "Nome da Rua é obrigatorio.")]
        public string NomeRua { get;  set; }

        [Required(ErrorMessage = "Numero da rua é obrigatorio.")]
        public int NumeroRua { get;  set; }

        public string? Complemento { get;  set; }

        [Required(ErrorMessage = "Bairro é obrigatorio.")]
        public string Bairro { get;  set; }

        [Required(ErrorMessage = "Cidade é obrigatorio.")]
        public string Cidade { get;  set; }

        [Required(ErrorMessage = "Estado é obrigatorio.")]
        public string Estado { get;  set; }

        [Required(ErrorMessage = "CEP é obrigatorio.")]
        public string Sigla { get;  set; }
    }
}
