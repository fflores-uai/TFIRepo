﻿namespace TFI.CORE.Entities
{
    public class LenguajeControl
    {
        public int LenguajeID { get; set; }
        public string Control { get; set; }
        public string Valor { get; set; }

        public Lenguaje Lenguaje { get; set; }
    }
}