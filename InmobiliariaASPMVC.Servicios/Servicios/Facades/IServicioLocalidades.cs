using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios.Facades
{
    public interface IServicioLocalidades
    {
        List<LocalidadListDto> GetLista(string provincia);
        void Guardar(LocalidadEditDto localidadDto);
        bool Existe(LocalidadEditDto localidadEditDto);
        LocalidadEditDto GetLocalidadPorId(int? id);
        void Borrar(int provinciaVmLocalidadId);

    }
}
