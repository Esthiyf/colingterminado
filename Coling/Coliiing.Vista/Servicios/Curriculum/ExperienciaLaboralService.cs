using Coliiing.Vista.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Servicios.Curriculum
{
    public class ExperienciaLaboralService : IExperienciaLaboralService
    {
        string url = " http://localhost:7264";
        string endPoint = "";
        HttpClient client = new HttpClient();

        public ExperienciaLaboralService(HttpClient httClient)
        {
            client = httClient;
            client.BaseAddress = new Uri(url);
        }
        public async Task<bool> EditarExperienciaLaboral(ExperienciaLaboral experienciaLaboral)
        {
            bool sw = false;
            endPoint = url + "/api/ModificarExperiencia";
            string jsonBody = JsonConvert.SerializeObject(experienciaLaboral);
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EliminarExperienciaLaboral(string partitionkey, string rowkey)
        {
            bool sw = false;
            endPoint = url + "/api/EliminarExperiencia/" + partitionkey + "/" + rowkey;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> InsertarExperienciaLaboral(ExperienciaLaboral experienciaLaboral)
        {
            bool sw = false;
            endPoint = url + "/api/InsertarExperienciaLaboral";
            string jsonBody = JsonConvert.SerializeObject(experienciaLaboral);
            // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<List<ExperienciaLaboral>> ListaExperienciaLaboral()
        {
            endPoint = "api/ListarExperiencia";
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<ExperienciaLaboral> result = new List<ExperienciaLaboral>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<ExperienciaLaboral>>(respuestaCuerpo);
            }
            return result;
        }

        public async Task<ExperienciaLaboral> ObtenerExperienciaLaboralById(string rowkey)
        {
            endPoint = "/api/obtenerExperienciaById/" + rowkey;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            ExperienciaLaboral estudios = new ExperienciaLaboral();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                estudios = JsonConvert.DeserializeObject<ExperienciaLaboral>(respuestaCuerpo);
            }
            return estudios;
        }
    }
}
