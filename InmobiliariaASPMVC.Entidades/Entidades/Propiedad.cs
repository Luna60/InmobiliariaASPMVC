using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.Entidades
{
    public class Propiedad
    {
        public int PropiedadId { get; set; }

        public string Descripcion { get; set; }
        public string Disponible { get; set; }

        public int TipoPropiedadId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public TipoPropiedad TipoPropiedad { get; set; }
        public int TipoOperacionId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public TipoOperacion TipoOperacion { get; set; }

        public int ProvinciaId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public Provincia Provincia { get; set; }
        public int LocalidadId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public Localidad Localidad { get; set; }

    }
}
