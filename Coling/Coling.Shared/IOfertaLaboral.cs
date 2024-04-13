using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Shared
{
    public interface IOfertaLaboral
    {
        public string Institucion { get; set; } 

        public DateTime FechaOferta { get; set; }

        public DateTime FechaLimite { get; set; }

        public string Descripcion { get; set; } 

        public string? Cargo { get; set; }
        public string Contrato { get; set; } 
     
        public string Area { get; set; }

        public string Estado { get; set; } 
    }
}
