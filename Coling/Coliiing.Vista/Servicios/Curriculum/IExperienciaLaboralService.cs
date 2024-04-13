using Coliiing.Vista.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Servicios.Curriculum
{
    public interface IExperienciaLaboralService
    {
        Task<List<ExperienciaLaboral>> ListaExperienciaLaboral();
        Task<bool> InsertarExperienciaLaboral(ExperienciaLaboral experienciaLaboral); //string token
        Task<bool> EliminarExperienciaLaboral(string partitionkey, string rowkey);
        Task<bool> EditarExperienciaLaboral(ExperienciaLaboral experienciaLaboral);
        Task<ExperienciaLaboral> ObtenerExperienciaLaboralById(string rowkey);
    }
}
