using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coliiing.Vista.Modelos;

namespace Coliiing.Vista.Servicios.Curriculum
{
    public interface IProfesionService
    {
        Task<List<Profesion>> ListaProfesion();
        Task<bool> InsertarProfesion(Profesion profesion); //string token
        Task<bool> EliminarProfesion(string partitionkey, string rowkey);
        Task<bool> EditarProfesion(Profesion profesion);
        Task<Profesion> ObtenerProfesionById(string rowkey);
    }
}
