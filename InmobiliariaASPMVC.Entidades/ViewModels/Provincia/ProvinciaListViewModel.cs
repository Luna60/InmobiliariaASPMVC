using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.Provincia
{
    public class ProvinciaListViewModel
    {
        public int ProvinciaId { get; set; }

        [Display (Name = "Provincias")]
        public string NombreProvincia { get; set; }

    }
}
