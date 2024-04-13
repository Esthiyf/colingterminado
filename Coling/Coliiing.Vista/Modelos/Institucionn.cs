
using Coling.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Modelos
{
    public class Institucionn: IInstitucion
    {
        [Display(Name = "Nombre")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo  {0} debe tener maximo  {1} caracteres")]
        public string Nombre { get; set; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo  {0} debe tener maximo  {1} caracteres")]
        public string Tipo { get; set; }

        [Display(Name = "Direccion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo  {0} debe tener maximo  {1} caracteres")]
        public string Direccion { get; set; }
        public string Estado { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public string ETag { get; set; }
    }
}
