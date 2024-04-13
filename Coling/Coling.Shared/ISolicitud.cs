using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Shared
{
    public interface ISolicitud
    {
        public int? Afiliado { get; set; }
        public string? Oferta { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public DateTime FechaPostulacion { get; set; }
        public double PretencionSalarial { get; set; }       
        public string? Curriculum { get; set; }
        public string? Estado { get; set; } 
    }
}
