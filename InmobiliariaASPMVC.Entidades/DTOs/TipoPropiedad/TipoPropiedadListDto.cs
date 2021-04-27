using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad
{
    public class TipoPropiedadListDto : ICloneable
    {
        public int TipoPropiedadId { get; set; }
        public string DescripcionTP { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
