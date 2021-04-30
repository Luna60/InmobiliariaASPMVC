using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Propiedad
{
    public class PropiedadDetailsViewModel
    {
        public int PropiedadId { get; set; }

        [Display(Name = "Descripción")]
        public string DescripcionP { get; set; }

        [Display(Name = "Tipo de Propiedad")]
        public string TipoPropiedad { get; set; }

        [Display(Name = "Tipo de Operacion")]
        public string TipoOperacion { get; set; }

        public decimal CostoOperacion { get; set; }
        public decimal ValorPropiedad { get; set; }

        public string Detalles { get; set; }

        //[DataType(DataType.ImageUrl)]
        //public string Imagen { get; set; }

        public bool Disponible { get; set; }


    }
}
