using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.TipoOperacion
{
    public class TipoOperacionListViewModel
    {
        public int TipoOperacionId { get; set; }

        [Display(Name = "Tipo de Operacion")]
        public string DescripcionTO { get; set; }

    }
}
