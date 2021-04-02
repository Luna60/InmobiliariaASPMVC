using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.Propiedad
{
    public class PropiedadListDto
    {
        public int PropiedadId { get; set; }
        public string Descripcion { get; set; }
        public string TipoPropiedad { get; set; }
        public string TipoOperacion { get; set; }
        public string Provincia { get; set; }
        public string Localidad { get; set; }

    }
}
