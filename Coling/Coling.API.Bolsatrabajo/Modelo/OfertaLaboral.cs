using Coling.Shared;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Data.Tables;
using Azure;

namespace Coling.API.Bolsatrabajo.Modelo
{
    public class OfertaLaboral : IOfertaLaboral, ITableEntity
    {
        public string? Institucion { get; set; }
        public DateTime FechaOferta { get; set; }
        public DateTime FechaLimite { get; set; }
        public string? Descripcion { get; set; }
        public string? Cargo { get; set; }
        public string? Contrato { get; set; }
        public string? Area { get; set; }
        public string? Estado { get; set; }
        public string? PartitionKey { get; set; }
        public string? RowKey { get; set; }
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }
    }
}
