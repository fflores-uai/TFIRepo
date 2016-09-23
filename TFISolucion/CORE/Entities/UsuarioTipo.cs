namespace TFI.CORE.Entities
{
    public class UsuarioTipo
    {
        public enum Options
        {
            Administrador = 1,
            Cliente = 2,
            Empresa = 3
        }

        public int ID { get; set; }
        public string Descripcion { get; set; }
    }
}