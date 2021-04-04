using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.Cliente
{
    public class ClienteEditDto
    {
        public int ClienteId { get; set; }

        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int TipoDocumentoId { get; set; }
        public string NroDocumento { get; set; }
        public string Direccion { get; set; }

        public int LocalidadId { get; set; }
        public int ProvinciaId { get; set; }
        public string TelefonoFijo { get; set; }
        public string TelefonoMovil { get; set; }
        public string CorreElectronico { get; set; }


    }
}
