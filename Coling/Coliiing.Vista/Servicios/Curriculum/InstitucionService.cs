using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coliiing.Vista.Modelos;
using Coling.Shared;
using Newtonsoft.Json;
using CurrieTechnologies.Razor.SweetAlert2;
namespace Coliiing.Vista.Servicios.Curriculum
{
    public class InstitucionService: IInstitucionService
    {
        string url = " http://localhost:7264";
        string endPoint = "";
        HttpClient client = new HttpClient();

        public InstitucionService(HttpClient httClient)
        {
            client = httClient;
            client.BaseAddress = new Uri(url);
        }
        public async Task<List<Institucionn>> ListaInstitucion()
        {
            endPoint = "api/ListarInstitucion";
            client.BaseAddress = new Uri(url);

           // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<Institucionn> result = new List<Institucionn>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Institucionn>>(respuestaCuerpo);
            }
            return result;
        }

        public async Task<bool> InsertarInstitucion(Institucionn institucion)
        {
            bool sw = false;
            endPoint = url + "/api/InsertarInstitucion";
            string jsonBody = JsonConvert.SerializeObject(institucion);
           // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EliminarInstitucion(string partitionkey, string rowkey)
        {
            bool sw = false;
            endPoint = url + "/api/EliminarInstitucion/" + partitionkey + "/" + rowkey;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EditarInstitucion(Institucionn institucion)
        {
            bool sw = false;
            endPoint = url + "/api/ModificarInstitucion";
            string jsonBody = JsonConvert.SerializeObject(institucion);
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<Institucionn> ObtenerInstitucionById(string rowkey)
        {

            endPoint = "/api/obtenerInstitucionById/" + rowkey;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            Institucionn institucion = new Institucionn();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                institucion = JsonConvert.DeserializeObject<Institucionn>(respuestaCuerpo);
            }
            return institucion;
        }






        /*public async Task<bool> InsertarInstitucion(Institucion institucion, string token)
        {
            bool sw = false;
            endPoint = url + "/api/InsertarInstitucion";
            string jsonBody = JsonConvert.SerializeObject(institucion);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }*/
        /* public async Task<List<Institucion>> ListaInstituciones(string token)
         {
             endPoint = "api/ListarInstitucion";
             client.BaseAddress = new Uri(url);

             client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

             HttpResponseMessage response = await client.GetAsync(endPoint);
             List<Institucion> result = new List<Institucion>();
             if (response.IsSuccessStatusCode)
             {
                 string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                 result = JsonConvert.DeserializeObject<List<Institucion>>(respuestaCuerpo);
             }
             return result;
         }*/
    }
}
