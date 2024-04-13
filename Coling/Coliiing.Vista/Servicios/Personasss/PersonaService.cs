
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coling.Shared;
using Coliiing.Vista.Servicios.Personasss;


namespace Coliiing.Vista.Servicios.Personasss
{
    public class PersonaService: IPersonaservice
    {
        string url = "http://localhost:7115";
        string endPoint = "";
        HttpClient client = new HttpClient();

        public async Task<List<Persona>> Listapersona()
        {
            endPoint = "api/ListarPersonas";
            client.BaseAddress = new Uri(url);

            // client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token);

            HttpResponseMessage response = await client.GetAsync(endPoint);
            List<Persona> result = new List<Persona>();
            if (response.IsSuccessStatusCode)
            {
                string respuestaCuerpo = await response.Content.ReadAsStringAsync();
                result = JsonConvert.DeserializeObject<List<Persona>>(respuestaCuerpo);
            }
            return result;
        }
    }
}
