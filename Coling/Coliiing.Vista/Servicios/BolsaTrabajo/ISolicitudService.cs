using Coliiing.Vista.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coliiing.Vista.Servicios.BolsaTrabajo
{
    public interface ISolicitudService
    {
        Task<List<Solicitud>> ListaSolicitud();
        Task<bool> InsertarSolicitud(Solicitud solicitud); //string token
        Task<bool> EliminarSolicitud(string partitionkey, string rowkey);
        Task<bool> EditarSolicitud(Solicitud solicitud);
        Task<Solicitud> ObtenerSolicitudById(string rowkey);
    }
}
