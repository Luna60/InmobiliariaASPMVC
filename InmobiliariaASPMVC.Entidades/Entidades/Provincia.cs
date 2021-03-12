using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.Entidades
{
    public class Provincia
    {
        public int ProvinciaId { get; set; }

        //[DisplayName (@"Provincias")]
        public string NombreProvincia { get; set; }
    }
}
