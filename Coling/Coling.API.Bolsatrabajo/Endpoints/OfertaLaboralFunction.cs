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
    public class OfertaLaboralFunction
    {
        private readonly ILogger<OfertaLaboralFunction> _logger;
        private readonly IOfertaLaboralRepositorio repos;



        public OfertaLaboralFunction(ILogger<OfertaLaboralFunction> logger, IOfertaLaboralRepositorio repos)
        {
            _logger = logger;
            this.repos = repos;
        }

        [Function("InsertarOfertaLaboral")]
        //[ColingAuthorize(AplicacionRoles.Admin)]
        [OpenApiOperation("Insertarspec", "InsertarOfertaLaboral", Description = "Sirve para Insertar una Oferta")]
        [OpenApiRequestBody("application/json", typeof(OfertaLaboral), Description = "OfertaLaboral modelo")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(OfertaLaboral), Description = "Mostrara la Oferta Laboral Creada")]
        public async Task<HttpResponseData> InsertarOfertaLaboral([HttpTrigger(AuthorizationLevel.Anonymous, "post")] HttpRequestData req)
        {
            HttpResponseData respuesta;
            try
            {
                var registro = await req.ReadFromJsonAsync<OfertaLaboral>() ?? throw new Exception("Debe ingresar con todos sus datos");
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



        [Function("ListarOfertaLaboral")]
        // [ColingAuthorize(AplicacionRoles.Admin+","+ AplicacionRoles.Afiliado + "," + AplicacionRoles.Secretaria)]
        [OpenApiOperation("Listarspec", "ListarOfertaLaboral", Description = "Sirve para listar todas las Ofertas Laborales")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<OfertaLaboral>),
            Description = "Mostrara una lista de Ofertas Laborales")]
        public async Task<HttpResponseData> ListarOfertaLaboral([HttpTrigger(AuthorizationLevel.Anonymous, "get")] HttpRequestData req)
        {
            HttpResponseData respuesta;
            try
            {
                var lista = repos.ListarOfertas();
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


        [Function("ObtenerOfertaLaboralById")]
        [OpenApiOperation("Obtenerspec", "ObtenerOfertaLaboralById", Description = "Sirve para obtener una Oferta")]
        [OpenApiParameter(name: "rowkey", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(OfertaLaboral), Description = "Mostrara una oferta laboral")]
        public async Task<HttpResponseData> ObtenerOfertaLaboralById([HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "obtenerOfertaLaboralById/{rowKey}")] HttpRequestData req, string rowkey)
        {
            HttpResponseData respuesta;
            try
            {
                var institucion = repos.ObtenerOfertabyId(rowkey);
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

        [Function("ModificarOfertaLaboral")]
        //   [ColingAuthorize(AplicacionRoles.Admin + ","  + AplicacionRoles.Secretaria)]
        [OpenApiOperation("Modificarspec", "ModificarOfertaLaboral", Description = "Sirve para Modificar una oferta laboral")]
        [OpenApiRequestBody("application/json", typeof(OfertaLaboral), Description = "oferta Laboral modelo")]
        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(OfertaLaboral),
           Description = "Mostrara la oferta laboral modificada")]
        public async Task<HttpResponseData> ModificarOfertaLaboral([HttpTrigger(AuthorizationLevel.Anonymous, "put", Route = "ModificarOfertaLaboral")] HttpRequestData req)
        {
            HttpResponseData respuesta;
            try
            {
                var registro = await req.ReadFromJsonAsync<OfertaLaboral>() ?? throw new Exception("Debe ingresar con todos sus datos");
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



        [Function("EliminarOfertarLaboral")]
        //  [ColingAuthorize(AplicacionRoles.Admin )]
        [OpenApiOperation("Eliminarspec", "EliminarOfertaLaboral", Description = "Sirve para Eliminar una oferta laboral")]
        [OpenApiParameter(name: "partitionkey", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        [OpenApiParameter(name: "rowkey", In = ParameterLocation.Path, Required = true, Type = typeof(string))]
        public async Task<HttpResponseData> EliminarOfertaLaboral([HttpTrigger(AuthorizationLevel.Anonymous, "delete", Route = "EliminarOfertaLaboral/{partitionkey}/{rowkey}")] HttpRequestData req, string partitionkey, string rowkey)
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
