using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios.Facades
{
    public interface IServiciosPropiedades
    {
        List<PropiedadListDto> GetLista(string provincia);
        void Guardar(PropiedadEditDto propiedadDto);
        bool Existe(PropiedadEditDto propiedadEditDto);
        PropiedadEditDto GetPropiedadPorId(int? id);
        void Borrar(int PropiedadId);


    }
}
