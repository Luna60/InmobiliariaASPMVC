using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Entidades.Entidades;
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
        void Guardar(TipoOperacion tipoOperacion);
        void Borrar(int? id);
        bool Existe(TipoOperacion tipoOperacion);

    }
}
