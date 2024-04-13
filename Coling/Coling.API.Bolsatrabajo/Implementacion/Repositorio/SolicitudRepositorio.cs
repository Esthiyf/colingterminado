using Azure.Data.Tables;
using Coling.API.Bolsatrabajo.Contratos.Repositorio;
using Coling.API.Bolsatrabajo.Modelo;
using Coling.Shared;
using Microsoft.Extensions.Configuration;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.API.Bolsatrabajo.Repositorio
{
    public class SolicitudRepositorio : ISolicitudRepositorio
    {
        private readonly string? cadenaConexion;
        private readonly string tablaNombre;
        private readonly IConfiguration configuration;
        public SolicitudRepositorio(IConfiguration conf)
        {
            configuration = conf;
            cadenaConexion = configuration.GetSection("cadenaconexion").Value;
            tablaNombre = "Solicitud";
        }
        public async Task<bool> Eliminar(string partitionKey, string rowKey)
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

        public async Task<bool> Insertar(Solicitud solicitud)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.UpsertEntityAsync(solicitud);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<List<Solicitud>> ListarSolicitudes()
        {
            List<Solicitud> lista = new List<Solicitud>();
            var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
            var filtro = $"PartitionKey eq 'Solicitud'";

            await foreach (Solicitud solicitud in tablaCliente.QueryAsync<Solicitud>(filter: filtro))
            {
                lista.Add(solicitud);
            }

            return lista;
        }

        public async Task<bool> Modificar(Solicitud solicitud)
        {
            try
            {
                var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
                await tablaCliente.UpdateEntityAsync(solicitud, solicitud.ETag);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Solicitud> ObtenerSolicitudbyId(string rowKey)
        {
            var tablaCliente = new TableClient(cadenaConexion, tablaNombre);
            var experiencia = await tablaCliente.GetEntityAsync<Solicitud>("Solicitud", rowKey);
            return experiencia.Value;
        }
    }
}

