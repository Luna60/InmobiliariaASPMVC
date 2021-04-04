using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios.Facades
{
    public interface IRepositoriosTiposOperaciones
    {
        List<TipoOperacionListDto> GetLista();
        TipoOperacionEditDto GetTipoOperacionPorId(int? id);

    }
}
