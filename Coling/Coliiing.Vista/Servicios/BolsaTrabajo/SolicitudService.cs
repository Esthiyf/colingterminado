using Coliiing.Vista.Modelos;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Servicios.BolsaTrabajo
{
    public class SolicitudService : ISolicitudService
    {
        string url = " http://localhost:7066";
        string endPoint = "";
        HttpClient client = new HttpClient();

        public SolicitudService(HttpClient httClient)
        {
            client = httClient;
            client.BaseAddress = new Uri(url);
        }
        public async Task<bool> EditarSolicitud(Solicitud solicitud)
        {
            bool sw = false;
            endPoint = url + "/api/ModificarSolicitud";
            string jsonBody = JsonConvert.SerializeObject(solicitud);
            //client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer");
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PutAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> EliminarSolicitud(string partitionkey, string rowkey)
        {
            bool sw = false;
            endPoint = url + "/api/EliminarSolicitud/" + partitionkey + "/" + rowkey;
            HttpResponseMessage respuesta = await client.DeleteAsync(endPoint);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<bool> InsertarSolicitud(Solicitud solicitud)
        {
            bool sw = false;
            endPoint = url + "/api/InsertarSolicitud";
            string jsonBody = JsonConvert.SerializeObject(solicitud);
            // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);
            HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
            HttpResponseMessage respuesta = await client.PostAsync(endPoint, content);
            if (respuesta.IsSuccessStatusCode)
            {
                sw = true;
            }
            return sw;
        }

        public async Task<List<Solicitud>> ListaSolicitud()
        {
            endPoint = "api/ListarSolicitud";
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<Solicitud> result = new List<Solicitud>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Solicitud>>(respuestaCuerpo);
            }
            return result;
        }

        public async Task<Solicitud> ObtenerSolicitudById(string rowkey)
        {
            endPoint = "/api/obtenerSolicitudById/" + rowkey;
            client.BaseAddress = new Uri(url);
            HttpResponseMessage respuesta = await client.GetAsync(endPoint);
            Solicitud estudios = new Solicitud();
            if (respuesta.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await respuesta.Content.ReadAsStringAsync();
                estudios = JsonConvert.DeserializeObject<Solicitud>(respuestaCuerpo);
            }
            return estudios;
        }
    }
}
