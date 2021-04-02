using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.Entidades
{
    public class Localidad
    {
        public int LocalidadId { get; set; }

        public string NombreLocalidad { get; set; }
        public int ProvinciaId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public Provincia Provincia { get; set; }
    }
}
