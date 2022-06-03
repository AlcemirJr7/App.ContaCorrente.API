namespace App.ContaCorrente.Domain.Enumerador
{
    public enum EnumTransferenciaTipo
    {
        Ted = 1,      
        Pix = 2
    }

    public enum EnumTransferenciaModo
    {
        Interna = 1,
        Externa = 2
        
    }

    public enum EnumTransferenciaInternaHistoricoPix
    {
        RecebePix = 5,
        EnviaPix = 6
    }

    public enum EnumTransferenciaInternaHistoricoTed
    {
        RecebeTed = 7,
        EnviaTed = 8
    }

    public enum EnumTransferenciaExternaHistoricoPix
    {
        RecebePix = 1007,
        EnviaPix = 1008
    }
}
