using Coliiing.Vista.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Servicios.BolsaTrabajo
{
    public interface IOfertaLaboralService
    {
        Task<List<OfertaLaboral>> ListaOfertaLaboral();
        Task<bool> InsertarOfertaLaboral(OfertaLaboral ofertalaboral); //string token
        Task<bool> EliminarOfertaLaboral(string partitionkey, string rowkey);
        Task<bool> EditarOfertaLaboral(OfertaLaboral ofertalaboral);
        Task<OfertaLaboral> ObtenerOfertaLaboralById(string rowkey);
    }
}
