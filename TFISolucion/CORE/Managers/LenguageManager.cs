using System.Collections.Generic;
using System.Linq;

namespace TFI.CORE.Managers
{
    public class LenguageManager
    {
        public static IDictionary<string, string> UpdateDiccionario(string language)
        {
            var diccionario = new Dictionary<string, string>();

            var leng = FindByLenguage(language)
                            .ToDictionary(key => key.Control,
                                          val => val.Value);

            diccionario.Concat(leng);

            return diccionario;
        }

        private static IEnumerable<Entities.Lenguaje> FindByLenguage(string lenguage)
        {
            var language = new List<Entities.Lenguaje>();

            //MAPPER.QUERY.SELECTALLL

            //MOCK EJEMPLO
            language.Add(new Entities.Lenguaje
                {
                    Control = "Nombre",
                    IsoCode = "en",
                    Value = "Name"
                });

            language.Add(new Entities.Lenguaje
                {
                    Control = "Nombre",
                    IsoCode = "es",
                    Value = "Nombre"
                });

            return language
                        .Where(x => x.IsoCode == lenguage);
        }
    }
}