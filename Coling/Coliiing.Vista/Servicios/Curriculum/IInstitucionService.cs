using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Coliiing.Vista.Modelos;

namespace Coliiing.Vista.Servicios.Curriculum
{
    public interface IInstitucionService
    {
        Task<List<Institucionn>> ListaInstitucion();
        Task<bool> InsertarInstitucion(Institucionn institucion); //string token
        Task<bool> EliminarInstitucion(string partitionkey, string rowkey);
        Task<bool> EditarInstitucion(Institucionn institucion);
        Task<Institucionn> ObtenerInstitucionById(string rowkey);
    }
}
