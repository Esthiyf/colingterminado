using Azure.Data.Tables;
using Coling.API.Bolsatrabajo.Contratos.Repositorio;
using Coling.API.Bolsatrabajo.Modelo;
using Coling.Shared;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.API.Bolsatrabajo.Implementacion.Repositorio
{
    public class OfertaLaboralRepositorio : IOfertaLaboralRepositorio
    {
        private readonly string? cadenaConexion;
        private readonly string tablaNombre;
        private readonly IConfiguration configuration;
        public OfertaLaboralRepositorio(IConfiguration conf)
        {
            configuration = conf;
            cadenaConexion = configuration.GetSection("cadenaconexion").Value;
            tablaNombre = "OfertaLaboral";
        }
        public async Task<bool> Eliminar(string partitionKey,string rowKey)
        {
            try
            {
                var tableCliente = new TableClient(cadenaConexion, tablaNombre);
                await tableCliente.DeleteEntityAsync(partitionKey, rowKey);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<bool> Insertar(OfertaLaboral ofertaLaboral)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.UpsertEntityAsync(ofertaLaboral);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<OfertaLaboral>> ListarOfertas()
        {
            List<OfertaLaboral> lista = new List<OfertaLaboral>();
            var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
            var filtro = $"PartitionKey eq 'OfertaLaboral'";

            await foreach (OfertaLaboral ofertaLab in tablaCliente.QueryAsync<OfertaLaboral>(filter: filtro))
            {
                lista.Add(ofertaLab);
            }

            return lista;
        }

        public async Task<bool> Modificar(OfertaLaboral ofertaLaboral)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.UpdateEntityAsync(ofertaLaboral, ofertaLaboral.ETag);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<OfertaLaboral> ObtenerOfertabyId(string rowKey)
        {
            var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
            var experiencia = await tablaCliente.GetEntityAsync<OfertaLaboral>("OfertaLaboral", rowKey);
            return experiencia.Value;
        }
    }
}
