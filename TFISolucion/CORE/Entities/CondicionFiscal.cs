namespace TFI.CORE.Entities
{
    public class CondicionFiscal
    {
        public enum Options
        {
            ConsumidorFinal = 1,
            ResponsableInscripto = 2
        }

        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}