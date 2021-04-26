﻿using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.EntityTypeConfiguration
{
    class PropiedadEntityTypeConfiguration : EntityTypeConfiguration<Propiedad>
    {
        public PropiedadEntityTypeConfiguration()
        {
            ToTable("Propiedades");
        }

    }
}
