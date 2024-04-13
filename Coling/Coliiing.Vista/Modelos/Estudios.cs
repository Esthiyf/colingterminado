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
    public class Estudios : IEstudios
    {
       
        public int IdAfiliado { get; set; }
        [Display(Name = "IdProfesion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo  {0} debe tener maximo  {1} caracteres")]
        public string IdProfesion { get; set; }
        [Display(Name = "IdInstitucion")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo  {0} debe tener maximo  {1} caracteres")]
        public string IdInstitucion { get; set; }
        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo  {0} debe tener maximo  {1} caracteres")]
        public string Tipo { get; set; }
        [Display(Name = "TituloRecido")]
        [Required(ErrorMessage = "El Campo {0} es requerido")]
        [MaxLength(100, ErrorMessage = "El campo  {0} debe tener maximo  {1} caracteres")]
        public string TituloRecido { get; set; }
   
        public int Anio { get; set; }
        public string Estado { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public string ETag { get; set; }
    }
}
