using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.DTOs.Propiedad
{
    public class PropiedadEditDto
    {
        public int PropiedadId { get; set; }

        public string DescripcionP { get; set; }

        public int TipoOperacionId { get; set; }
        public int TipoPropiedadId { get; set; }
        public int ClienteId { get; set; }

        public DateTime FechaIngreso { get; set; }
        public bool Disponible { get; set; }
        public int Ambientes { get; set; }
        public int SuperficieTerreno { get; set; }
        public int SuperficieEdificada { get; set; }

        public string Direccion { get; set; }
        public string Departamento { get; set; }


        public bool Jardin { get; set; }
        public bool Garage { get; set; }

        public string Cochera { get; set; }

        public int LocalidadId { get; set; }
        public int ProvinciaId { get; set; }

        public decimal CostoOperacion { get; set; }
        public string Observaciones { get; set; }


    }
}
