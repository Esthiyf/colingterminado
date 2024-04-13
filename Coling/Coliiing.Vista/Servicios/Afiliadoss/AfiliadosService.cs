using Coling.Shared;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Servicios.Afiliadoss
{
    public class AfiliadosService : IAfiliadosService
    {
        string url = "http://localhost:7115";
        string endPoint = "";
        HttpClient client = new HttpClient();

        public async Task<bool> EditarAfiliado(Afiliado afiliado)
        {
            endPoint = $"api/EditarAfiliado/{afiliado.Id}";
            client.BaseAddress = new Uri(url);

            // Aquí puedes agregar cualquier lógica adicional para enviar datos al servidor para la edición

            HttpResponseMessage response = await client.PutAsJsonAsync(endPoint, afiliado);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> EliminarAfiliado(int id)
        {
            endPoint = $"api/EliminarAfiliado/{id}";
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.DeleteAsync(endPoint);
            return response.IsSuccessStatusCode;
        }

        public async Task<bool> InsertarAfiliado(Afiliado afiliado)
        {
            endPoint = "api/InsertarAfiliado";
            client.BaseAddress = new Uri(url);

            // Aquí puedes agregar cualquier lógica adicional para preparar los datos antes de enviarlos al servidor

            HttpResponseMessage response = await client.PostAsJsonAsync(endPoint, afiliado);
            return response.IsSuccessStatusCode;
        }

        public async Task<List<Afiliado>> ListaAfiliado()
        {
            endPoint = "api/ListarAfiliados";
            client.BaseAddress = new Uri(url);

            // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<Afiliado> result = new List<Afiliado>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Afiliado>>(respuestaCuerpo);
            }
            return result;
        }

        public async Task<Afiliado> ObtenerAfiliadoById(int id)
        {
            endPoint = $"api/ObtenerAfiliado/{id}";
            client.BaseAddress = new Uri(url);

            HttpResponseMessage response = await client.GetAsync(endPoint);
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Afiliado>(respuestaCuerpo);
            }
            else
            {
                return null; // o manejar el error de alguna otra manera
            }
        }
    }
}
