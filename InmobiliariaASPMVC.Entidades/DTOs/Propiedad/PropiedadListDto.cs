using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.Propiedad
{
    public class PropiedadListDto : ICloneable
    {
        public int PropiedadId { get; set; }
        public string Cliente { get; set; }
        public string DescripcionP { get; set; }

        public bool Disponible { get; set; }
        public decimal CostoOperacion { get; set; }

        public string TipoOperacion { get; set; }

        public string TipoPropiedad { get; set; }


        public string Localidad { get; set; }

        public string Provincia { get; set; }
        public object Clone()
        {
            return this.MemberwiseClone();
        }




    }
}
