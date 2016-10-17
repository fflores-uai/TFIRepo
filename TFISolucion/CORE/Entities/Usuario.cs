namespace TFI.CORE.Entities
{
    public class Usuario : IEntity
    {
        public int ID { get; set; }
        public int CUIT { get; set; }
        public int CondicionFiscalID { get; set; }
        public CondicionFiscal CondicionFiscal { get; set; }
        public int UsuarioTipoID { get; set; }
        public UsuarioTipo UsuarioTipo { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Dni { get; set; }
        public string Email { get; set; }
        public string NetworkID { get; set; }
        public string Clave { get; set; }
    }
}