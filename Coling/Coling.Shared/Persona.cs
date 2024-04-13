using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Shared
{
    public class Persona
    {
        [Key]
        public int Id { get; set; }

        [StringLength(maximumLength: 20)]
        public string Ci { get; set; } 

        [StringLength(maximumLength: 50)]
        public string Nombre { get; set; } 

        [StringLength(maximumLength: 150)]
        public string Apellidos { get; set; } 

        public DateTime FechaNacimiento { get; set; }

        [StringLength(maximumLength: 250)]
        public string? Foto { get; set; }

        [StringLength(maximumLength: 20)]
        public string Estado { get; set; } 

    }
}
