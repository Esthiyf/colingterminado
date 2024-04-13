using Coliiing.Vista.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Servicios.BolsaTrabajo
{
    public class OfertaLaboralService : IOfertaLaboralService
    {
        string url = " http://localhost:7066";
        string endPoint = "";
        HttpClient client = new HttpClient();

        public OfertaLaboralService(HttpClient httClient)
        {
            client = httClient;
            client.BaseAddress = new Uri(url);
        }
        public async Task<bool> EditarOfertaLaboral(OfertaLaboral ofertalaboral)
        {
            bool sw = false;
            endPoint = url + "/api/ModificarOfertaLaboral";
            string jsonBody = JsonConvert.SerializeObject(ofertalaboral);
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EliminarOfertaLaboral(string partitionkey, string rowkey)
        {
            bool sw = false;
            endPoint = url + "/api/EliminarOfertaLaboral/" + partitionkey + "/" + rowkey;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> InsertarOfertaLaboral(OfertaLaboral ofertalaboral)
        {
            bool sw = false;
            endPoint = url + "/api/InsertarOfertaLaboral";
            string jsonBody = JsonConvert.SerializeObject(ofertalaboral);
            // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<List<OfertaLaboral>> ListaOfertaLaboral()
        {
            endPoint = "api/ListarOfertaLaboral";
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<OfertaLaboral> result = new List<OfertaLaboral>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<OfertaLaboral>>(respuestaCuerpo);
            }
            return result;
        }

        public async Task<OfertaLaboral> ObtenerOfertaLaboralById(string rowkey)
        {
            endPoint = "/api/obtenerOfertaLaboralById/" + rowkey;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            OfertaLaboral estudios = new OfertaLaboral();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                estudios = JsonConvert.DeserializeObject<OfertaLaboral>(respuestaCuerpo);
            }
            return estudios;
        }
    }
}
