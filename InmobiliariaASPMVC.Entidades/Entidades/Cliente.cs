using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.Entidades
{
    public class Cliente
    {
        public int ClienteId { get; set; }
        public string Apellido { get; set; }
        public string NroDocumento { get; set; }
        public int ProvinciaId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public Provincia Provincia { get; set; }
        public int LocalidadId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public Localidad Localidad { get; set; }
        public string TelefonoMovil { get; set; }

    }
}
