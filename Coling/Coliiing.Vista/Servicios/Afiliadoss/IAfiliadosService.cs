using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coling.Shared;

namespace Coliiing.Vista.Servicios.Afiliadoss
{
    public interface IAfiliadosService
    {
        Task<List<Afiliado>> ListaAfiliado();
        Task<bool> InsertarAfiliado(Afiliado afiliado); //string token
        Task<bool> EliminarAfiliado(int id);
        Task<bool> EditarAfiliado(Afiliado afiliado);
        Task<Afiliado> ObtenerAfiliadoById(int id);
    }
}
