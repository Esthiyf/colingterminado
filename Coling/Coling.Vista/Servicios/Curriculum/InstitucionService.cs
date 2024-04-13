using Coling.Vista.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Azure.Core;
namespace Coling.Vista.Servicios.Curriculum
{
    public class InstitucionService : IInstitucionService
    {
        string url = " http://localhost:7515";
        string endPoint = "";
        HttpClient client = new HttpClient();

       

        public async Task<List<Institucion>> ListaInstituciones(string token)
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
        }
        public async Task<bool> InsertarInstitucion(Institucion institucion, string token)
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
        }

    
        public async Task<bool> EliminarInstitucion(string partitionkey, string rowkey, string token)
        {
            bool sw = false;
            endPoint = url + "/api/EliminarInstituto/" + partitionkey+"/"+rowkey;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EditarInstitucion(Institucion institucion, string token)
        {
            bool sw = false;
            endPoint = url + "/api/ModificarInstitucion";
            string jsonBody = JsonConvert.SerializeObject(institucion);
            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<Institucion>ObtenerInstitucionById(string rowkey,string token)
        {
            
           endPoint = "/api/obtenerInstitucionById/" + rowkey;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            Institucion institucion=new Institucion();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                institucion = JsonConvert.DeserializeObject<Institucion>(respuestaCuerpo);
            }
            return institucion;
        }
    }
    }


