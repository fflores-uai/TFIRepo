namespace TFI.CORE.Entities
{
    public class PagoTipo
    {
        public enum Options
        {
            Efectivo = 1,
            Tarjeta = 2,
            Transferencia = 3
        }

        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}