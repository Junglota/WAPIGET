using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WAPIGET.Models.Request
{
    public class conteoRequest
    {
        public string Marca { get; set; }
        public double? Precio { get; set; }
        public int? Condicion { get; set; }
        public int? Estatus { get; set; }
        public string Detalles { get; set; }
        public string Fotos { get; set; }
        public string Modelo { get; set; }
        public int? nYear { get; set; }

    }
}