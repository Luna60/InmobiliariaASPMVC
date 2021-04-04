using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios.Facades
{
    public interface IServiciosTiposOperaciones
    {
        List<TipoOperacionListDto> GetLista();
        TipoOperacionEditDto GetTipoOperacionPorId(int? id);

    }
}
