using Coliiing.Vista.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Servicios.Curriculum
{
    public interface IEstudiosService
    {
        Task<List<Estudios>> ListaEstudios();
        Task<bool> InsertarEstudios(Estudios estudios); //string token
        Task<bool> EliminarEstudios(string partitionkey, string rowkey);
        Task<bool> EditarEstudios(Estudios estudios);
        Task<Estudios> ObtenerEstudiosById(string rowkey);
    }
}
