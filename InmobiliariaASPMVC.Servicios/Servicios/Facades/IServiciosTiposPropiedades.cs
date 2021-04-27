using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios.Facades
{
    public interface IServiciosTiposPropiedades
    {
        List<TipoPropiedadListDto> GetLista();
        TipoPropiedadEditDto GetTipoPropiedadPorId(int? id);
        void Guardar(TipoPropiedadEditDto tipoPropiedad);
        void Borrar(int? id);
        bool Existe(TipoPropiedadEditDto tipoPropiedad);


    }
}
