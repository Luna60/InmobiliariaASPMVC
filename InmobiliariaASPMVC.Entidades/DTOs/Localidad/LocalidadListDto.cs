﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.Localidad
{
    public class LocalidadListDto
    {
        public int LocalidadId { get; set; }

        public string NombreLocalidad { get; set; }
        public string Provincia { get; set; }
    }
}
