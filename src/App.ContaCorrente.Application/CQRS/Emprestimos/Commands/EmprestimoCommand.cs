using App.ContaCorrente.Domain.Entidades;
using App.ContaCorrente.Domain.Enumerador;
using MediatR;

namespace App.ContaCorrente.Application.CQRS.Emprestimos.Commands
{
    public abstract class EmprestimoCommand : IRequest<Emprestimo>
    {
        public int Id { get; set; }

        public decimal Valor { get; set; }

        public EnumEmprestimoTipoFinalidade TipoFinalidade { get; set; }

        public EnumEmprestimoTipoEmprestimo TipoEmprestimo { get; set; }

        public decimal SaldoDevedor { get; set; }

        public EnumEmprestimoStatus Status { get; set; }

        public int QtdParcelas { get; set; }
        
        public decimal ValorParcela { get; set; }

        public decimal Juros { get; set; }
        
        public DateTime DataCadastro { get; set; }
        
        public DateTime? DataEfetivacao { get; set; }

        public DateTime? DataRejeicao { get; set; }

        public EnumFlagEstadoEmprestimo FlagEstado { get; set; }

        
        public EnumProcessoEmprestimo FlagProcesso { get; set; }

        public int CorrentistaId { get; set; }
    }
}
