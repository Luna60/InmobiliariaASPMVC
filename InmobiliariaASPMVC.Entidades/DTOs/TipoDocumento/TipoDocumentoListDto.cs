using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento
{
    public class TipoDocumentoListDto : ICloneable
    {
        public int TipoDocumentoId { get; set; }
        public string DescripcionTD { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

    }
}
