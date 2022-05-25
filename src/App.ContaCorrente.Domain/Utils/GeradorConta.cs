namespace App.ContaCorrente.Domain.Utils
{
    public static class GeradorConta
    {
        public static string GeraNumeroConta(DateTime value)
        {
            var now = value;
            var zeroDate = DateTime.MinValue.AddHours(now.Hour).AddMinutes(now.Minute).AddSeconds(now.Second).AddMilliseconds(now.Millisecond);
            var numeroConta = Convert.ToString(zeroDate.Ticks / 10000);
            return numeroConta;
        }
    }
}
