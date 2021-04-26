using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios.Facades
{
    public interface IRepositoriosPropiedades
    {
        List<PropiedadListDto> GetLista(string provincia);
        void Guardar(Propiedad propiedad);
        PropiedadEditDto GetPropiedadPorId(int? id);
        void Borrar(int PropiedadId);
        bool Existe(Propiedad propiedad);

    }
}
