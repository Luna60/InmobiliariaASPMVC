using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioLocalidades
    {
        List<LocalidadListDto> GetLista();
        //ProvinciaEditDto GetProvinciaPorId(int? id);
        //void Guardar(Provincia provincia);
        //void Borrar(int? id);
        //bool Existe(Provincia provincia);

    }
}
