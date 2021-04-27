using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion
{
    public class TipoOperacionListDto : ICloneable
    {
        public int TipoOperacionId { get; set; }
        public string DescripcionTO { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
