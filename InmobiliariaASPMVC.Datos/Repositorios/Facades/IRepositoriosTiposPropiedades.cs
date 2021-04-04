using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios.Facades
{
    public interface IRepositoriosTiposPropiedades
    {
        List<TipoPropiedadListDto> GetLista();
        TipoPropiedadEditDto GetTipoPropiedadPorId(int? id);

    }
}
