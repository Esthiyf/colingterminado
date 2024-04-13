using Coliiing.Vista.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Servicios.Curriculum
{
    public class ProfesionService : IProfesionService
    {
        string url = " http://localhost:7264";
        string endPoint = "";
        HttpClient client = new HttpClient();

        public ProfesionService(HttpClient httClient)
        {
            client = httClient;
            client.BaseAddress = new Uri(url);
        }
        public async Task<bool> EditarProfesion(Profesion profesion)
        {
            bool sw = false;
            endPoint = url + "/api/ModificarProfesion";
            string jsonBody = JsonConvert.SerializeObject(profesion);
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EliminarProfesion(string partitionkey, string rowkey)
        {
            bool sw = false;
            endPoint = url + "/api/EliminarProfesion/" + partitionkey + "/" + rowkey;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> InsertarProfesion(Profesion profesion)
        {
            bool sw = false;
            endPoint = url + "/api/InsertarProfesion";
            string jsonBody = JsonConvert.SerializeObject(profesion);
            // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<List<Profesion>> ListaProfesion()
        {
            endPoint = "api/ListarProfesion";
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<Profesion> result = new List<Profesion>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Profesion>>(respuestaCuerpo);
            }
            return result;
        }

        public async Task<Profesion> ObtenerProfesionById(string rowkey)
        {
            endPoint = "/api/obtenerProfesionById/" + rowkey;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            Profesion estudios = new Profesion();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                estudios = JsonConvert.DeserializeObject<Profesion>(respuestaCuerpo);
            }
            return estudios;
        }
    }
}
