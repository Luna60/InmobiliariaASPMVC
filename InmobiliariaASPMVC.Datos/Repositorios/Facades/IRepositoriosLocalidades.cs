using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios.Facades
{
    public interface IRepositoriosLocalidades
    {
        List<LocalidadListDto> GetLista();
        void Guardar(Localidad localidad);
        //ProvinciaEditDto GetProvinciaPorId(int? id);
        //void Borrar(int? id);
        bool Existe(Localidad localidad);

    }
}
