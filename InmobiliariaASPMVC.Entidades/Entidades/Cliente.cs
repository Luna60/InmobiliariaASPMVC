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
        public string Nombre { get; set; }
        public string Apellido { get; set; }


        public int TipoDocumentoId { get; set; }
        public TipoDocumento TipoDocumento { get; set; }
        public string NroDocumento { get; set; }
        public string Direccion { get; set; }


        public int LocalidadId { get; set; }
        public Localidad Localidad { get; set; }

        public int ProvinciaId { get; set; }
        //como tengo un Id de otra tabla, lo debo de apuntar a la tabla correspondiente
        public Provincia Provincia { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }

        public string CorreoElectronico { get; set; }

    }
}
