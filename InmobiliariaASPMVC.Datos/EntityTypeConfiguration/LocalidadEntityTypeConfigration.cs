using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.EntityTypeConfiguration
{
    public class LocalidadEntityTypeConfigration: EntityTypeConfiguration<Localidad>
    {
        public LocalidadEntityTypeConfigration()
        {
            ToTable("Localidades");
        }
    }
}
