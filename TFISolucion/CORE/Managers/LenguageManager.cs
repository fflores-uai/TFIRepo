using System.Collections.Generic;

namespace TFI.CORE.Managers
{
    public class LenguageManager
    {
        public static IDictionary<string, string> GetDiccionario(string language)
        {
            var dic = new Dictionary<string, string>();

            dic.Add("nombre", "Name");
            dic.Add("apellido", "Apellido");

            return dic;
        }
    }
}