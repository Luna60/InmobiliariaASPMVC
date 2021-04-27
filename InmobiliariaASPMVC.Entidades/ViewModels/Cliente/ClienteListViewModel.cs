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

        public string Apellido { get; set; }

        public string NroDocumento { get; set; }

        public string TelefonoMovil { get; set; }

        [Display(Name = "Localidades")]
        public string Localidad { get; set; }

        [Display(Name = "Provincias")]
        public string Provincia { get; set; }

    }
}
