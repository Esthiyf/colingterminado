using Coliiing.Vista.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Servicios.Curriculum
{
    public class EstudiosService : IEstudiosService
    {
        string url = " http://localhost:7264";
        string endPoint = "";
        HttpClient client = new HttpClient();

        public EstudiosService(HttpClient httClient)
        {
            client = httClient;
            client.BaseAddress = new Uri(url);
        }
        public async Task<bool> EditarEstudios(Estudios estudios)
        {
            bool sw = false;
            endPoint = url + "/api/ModificarEstudios";
            string jsonBody = JsonConvert.SerializeObject(estudios);
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EliminarEstudios(string partitionkey, string rowkey)
        {
            bool sw = false;
            endPoint = url + "/api/EliminarEstudios/" + partitionkey + "/" + rowkey;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> InsertarEstudios(Estudios estudios)
        {
            bool sw = false;
            endPoint = url + "/api/InsertarEstudios";
            string jsonBody = JsonConvert.SerializeObject(estudios);
            // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }
    

        public async Task<List<Estudios>> ListaEstudios()
        {
            endPoint = "api/ListarEstudios";
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<Estudios> result = new List<Estudios>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Estudios>>(respuestaCuerpo);
            }
            return result;
        }

        public async Task<Estudios> ObtenerEstudiosById(string rowkey)
        {
            endPoint = "/api/obtenerEstudiosById/" + rowkey;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            Estudios estudios = new Estudios();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                estudios = JsonConvert.DeserializeObject<Estudios>(respuestaCuerpo);
            }
            return estudios;
        }
    }
}
