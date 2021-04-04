using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios.Facades
{
    public interface IServicioLocalidades
    {
        List<LocalidadListDto> GetLista();
        void Guardar(LocalidadEditDto localidadDto);
        bool Existe(LocalidadEditDto localidadEditDto);
        //ProductoEditDto GetProductoPorId(int? id);
        //void Borrar(int tipoVmProductoId);

    }
}
