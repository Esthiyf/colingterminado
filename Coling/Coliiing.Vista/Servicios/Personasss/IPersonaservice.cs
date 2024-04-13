using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coliiing.Vista.Modelos;
using Coling.Shared;

namespace Coliiing.Vista.Servicios.Personasss
{
    public interface IPersonaservice
    {
        Task<List<Persona>> Listapersona();
    }
}
