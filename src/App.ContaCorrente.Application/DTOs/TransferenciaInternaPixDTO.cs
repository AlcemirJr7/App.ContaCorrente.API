﻿using App.ContaCorrente.Domain.Enumerador;
using System.Text.Json.Serialization;

namespace App.ContaCorrente.Application.DTOs
{
    public class TransferenciaInternaPixAgendaDTO
    {
        public TransferenciaInternaPixAgendaDTO()
        {

        }

        public int Id { get; set; }

        [JsonIgnore]
        public DateTime? DataTransferencia { get; set; }

        [JsonIgnore]
        public DateTime DataCadatro { get; set; }

        public decimal Valor { get; set; }

        [JsonIgnore]
        public EnumTransferenciaTipo TipoTransferencia { get; set; }
        
        [JsonIgnore]
        public EnumTransferenciaModo ModoTransferencia { get; set; }
                
        public DateTime? DataAgendamento { get; set; }

        public string? ChavePixRecebe { get; set; }

        public string? ChavePixEnvia { get; set; }

        public string? Mensagem { get; set; }

    }
}
