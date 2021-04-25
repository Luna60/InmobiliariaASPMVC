using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.Cliente
{
    public class ClienteListDto : ICloneable
    {
        public int ClienteId { get; set; }
        public string Apellido { get; set; }

        public string NroDocumento { get; set; }
        public string TelefonoMovil { get; set; }

        public string Localidad { get; set; }

        public string Provincia { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }
}
