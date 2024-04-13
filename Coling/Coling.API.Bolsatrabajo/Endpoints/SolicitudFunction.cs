using Coling.API.Bolsatrabajo.Contratos.Repositorio;
using Coling.API.Bolsatrabajo.Modelo;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System.Net;

namespace Coling.API.Bolsatrabajo.Endpoints
{
    public class SolicitudFunction
    {
        private readonly ILogger<SolicitudFunction> _logger;
        private readonly ISolicitudRepositorio repos;



        public SolicitudFunction(ILogger<SolicitudFunction> logger, ISolicitudRepositorio repos)
        {
            _logger = logger;
            this.repos = repos;
        }
        [Function("InsertarSolicitud")]
        //[ColingAuthorize(AplicacionRoles.Admin)]
        [OpenApiOperation("Insertarspec", "InsertarSolicitud", Description = "Sirve para Insertar una Solicitud")]
        [OpenApiRequestBody("application/json", typeof(Solicitud), Description = "Solicitud modelo")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Solicitud), Description = "Mostrara la Solicitud Creada")]
        public async Task<HttpResponseData> InsertarSolicitud([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            HttpResponseData respuesta;
            try
            {
                var registro = await req.ReadFromJsonAsync<Solicitud>() ?? throw new Exception("Debe ingresar con todos sus datos");
                registro.RowKey = Guid.NewGuid().ToString();
                registro.Timestamp = DateTime.Now;
                bool sw = await repos.Insertar(registro);
                if (sw)
                {
                    respuesta = req.CreateResponse(HttpStatusCode.OK);
                    return respuesta;

                }
                else
                {
                    respuesta = req.CreateResponse(HttpStatusCode.BadRequest);
                    return respuesta;
                }
            }
            catch (Exception)
            {

                respuesta = req.CreateResponse(HttpStatusCode.InternalServerError);
                return respuesta;
            }
        }


        [Function("ListarSolicitud")]
        // [ColingAuthorize(AplicacionRoles.Admin+","+ AplicacionRoles.Afiliado + "," + AplicacionRoles.Secretaria)]
        [OpenApiOperation("Listarspec", "ListarSolicitud", Description = "Sirve para listar todas las Solicitudes")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<Solicitud>),
            Description = "Mostrara una lista de Solicitudes")]
        public async Task<HttpResponseData> ListarSolicitud([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            HttpResponseData respuesta;
            try
            {
                var lista = repos.ListarSolicitudes();
                respuesta = req.CreateResponse(HttpStatusCode.OK);
                await respuesta.WriteAsJsonAsync(lista.Result);
                return respuesta;

            }
            catch (Exception)
            {

                respuesta = req.CreateResponse(HttpStatusCode.InternalServerError);
                return respuesta;
            }
        }


        [Function("ObtenerSolicitudById")]
        [OpenApiOperation("Obtenerspec", "ObtenerSolicitudById", Description = "Sirve para obtener una Solicitud")]
        [OpenApiParameter(name: "rowkey", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(OfertaLaboral), Description = "Mostrara una Solicitud")]
        public async Task<HttpResponseData> ObtenerSolicitudById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "obtenerSolicitudById/{rowkey}")] HttpRequestData req, string rowkey)
        {
            HttpResponseData respuesta;
            try
            {
                var institucion = repos.ObtenerSolicitudbyId(rowkey);
                respuesta = req.CreateResponse(HttpStatusCode.OK);
                await respuesta.WriteAsJsonAsync(institucion.Result);
                return respuesta;
            }
            catch (Exception)
            {

                respuesta = req.CreateResponse(HttpStatusCode.InternalServerError);
                return respuesta;
            }
        }


        [Function("ModificarSolicitud")]
        //   [ColingAuthorize(AplicacionRoles.Admin + ","  + AplicacionRoles.Secretaria)]
        [OpenApiOperation("Modificarspec", "ModificarSolicitud", Description = "Sirve para Modificar una Solicitud")]
        [OpenApiRequestBody("application/json", typeof(Solicitud), Description = "Solicitud modelo")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(Solicitud),
           Description = "Mostrara la Solicitud modificada")]
        public async Task<HttpResponseData> ModificarSolicitud([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "ModificarSolicitud")] HttpRequestData req)
        {
            HttpResponseData respuesta;
            try
            {
                var registro = await req.ReadFromJsonAsync<Solicitud>() ?? throw new Exception("Debe ingresar con todos sus datos");
                bool sw = await repos.Modificar(registro);
                if (sw)
                {
                    respuesta = req.CreateResponse(HttpStatusCode.OK);
                    return respuesta;

                }
                else
                {
                    respuesta = req.CreateResponse(HttpStatusCode.BadRequest);
                    return respuesta;
                }
            }
            catch (Exception)
            {

                respuesta = req.CreateResponse(HttpStatusCode.InternalServerError);
                return respuesta;
            }
        }


        [Function("EliminarSolicitud")]
        //  [ColingAuthorize(AplicacionRoles.Admin )]
        [OpenApiOperation("Eliminarspec", "EliminarSolicitud", Description = "Sirve para Eliminar una Solicitud")]
        [OpenApiParameter(name: "partitionkey", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiParameter(name: "rowkey", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        public async Task<HttpResponseData> EliminarSolicitud([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "EliminarOfertaLaboral/{partitionkey}/{rowkey}")] HttpRequestData req, string partitionkey, string rowkey)
        {
            HttpResponseData respuesta;
            try
            {
                bool sw = await repos.Eliminar(partitionkey, rowkey);
                if (sw)
                {
                    respuesta = req.CreateResponse(HttpStatusCode.OK);
                    return respuesta;

                }
                else
                {
                    respuesta = req.CreateResponse(HttpStatusCode.BadRequest);
                    return respuesta;
                }
            }
            catch (Exception)
            {

                respuesta = req.CreateResponse(HttpStatusCode.InternalServerError);
                return respuesta;
            }
        }

    }
}
