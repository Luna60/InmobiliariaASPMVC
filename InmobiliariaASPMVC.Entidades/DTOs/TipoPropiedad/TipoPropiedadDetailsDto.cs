using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad
{
    public class TipoPropiedadDetailsDto
    {
        public TipoPropiedadListDto Tipo { get; set; }
        public List<PropiedadListDto> PropiedadListDto { get; set; }

    }
}
