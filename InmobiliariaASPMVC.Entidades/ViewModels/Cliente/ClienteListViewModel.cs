using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Cliente
{
    public class ClienteListViewModel
    {
        public int ClienteId { get; set; }

        [Display(Name = "Apellido")]
        public string Apellido { get; set; }
        [Display(Name = "Disponible")]
        public bool Disponible { get; set; }

        [Display(Name = "Localidades")]
        public string Localidad { get; set; }

        [Display(Name = "Provincias")]
        public string Provincia { get; set; }


    }
}
