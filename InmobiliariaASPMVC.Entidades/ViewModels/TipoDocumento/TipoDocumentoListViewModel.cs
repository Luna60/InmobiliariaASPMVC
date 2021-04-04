using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.ViewModels.TipoDocumento
{
    public class TipoDocumentoListViewModel
    {
        public int TipoDocumentoId { get; set; }

        [Display(Name = "Tipo de Documento")]
        public string DescripcionTD { get; set; }

    }
}
