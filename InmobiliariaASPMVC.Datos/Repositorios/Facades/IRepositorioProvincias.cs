﻿using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioProvincias
    {
        List<ProvinciaListDto> GetLista();
        Provincia GetProvinciaPorId(int? id);
        void Guardar(Provincia provincia);
        void Borrar(int? id);
        bool Existe(Provincia provincia);
    }
}
