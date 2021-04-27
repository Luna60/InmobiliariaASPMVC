using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using InmobiliariaASPMVC.Entidades.Entidades;
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
        void Guardar(TipoPropiedad tipoPropiedad);
        void Borrar(int? id);
        bool Existe(TipoPropiedad tipoPropiedad);

    }
}
