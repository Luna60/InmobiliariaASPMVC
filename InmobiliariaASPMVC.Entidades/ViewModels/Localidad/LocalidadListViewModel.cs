using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Localidad
{
    public class LocalidadListViewModel
    {
        public int LocalidadId { get; set; }

        [Display(Name = "Localidades")]
        public string NombreLocalidad { get; set; }

        [Display(Name = "Provincias")]
        public string Provincia { get; set; }

    }
}
