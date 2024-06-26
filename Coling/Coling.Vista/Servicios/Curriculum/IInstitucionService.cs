﻿using Coling.Vista.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coling.Vista.Servicios.Curriculum
{
    public interface IInstitucionService
    {
        Task<List<Institucion>> ListaInstituciones(string token);
        Task<bool> InsertarInstitucion(Institucion institucion, string token);
        Task<bool> EliminarInstitucion( string partitionkey,string rowkey, string token);
        Task<bool> EditarInstitucion(Institucion institucion, string token);
        Task<Institucion> ObtenerInstitucionById(string rowkey,string token);

    }
}
