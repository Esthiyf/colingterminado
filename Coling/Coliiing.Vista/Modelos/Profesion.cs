using Azure;
using Azure.Data.Tables;
using Coling.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Modelos
{
    public class Profesion : IProfesion
    {
        [Display(Name = "NombreProfesion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo  {0} debe tener maximo  {1} caracteres")]
        public string NombreProfesion {  get; set; }
        [Display(Name = "NombreGrado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo  {0} debe tener maximo  {1} caracteres")]
        public string NombreGrado { get; set; }
        [Display(Name = "Estado")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo  {0} debe tener maximo  {1} caracteres")]
        public string Estado { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public string ETag { get; set; }
    }
}
