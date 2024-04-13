using Azure;
using Azure.Data.Tables;
using Coling.Shared;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.API.Bolsatrabajo.Modelo
{
   public class Solicitud : ISolicitud, ITableEntity
    {
        public int? Afiliado { get; set; }
        public string? Oferta { get; set; }
        public string? Nombre { get; set; }
        public string? Apellidos { get; set; }
        public DateTime FechaPostulacion { get; set; }
        public double PretencionSalarial { get; set; }
        public string? Curriculum { get; set; }
        public string? Estado { get; set; }
        public string PartitionKey { get; set; }
        public string RowKey { get; set; }
        public DateTimeOffset? Timestamp { get ;set; }
        public ETag ETag { get; set; }
    }
}
