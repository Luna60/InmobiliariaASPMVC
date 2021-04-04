using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios.Facades
{
    public interface IRepositoriosClientes
    {
        List<ClienteListDto> GetLista();
        void Guardar(Cliente cliente);
        //ProvinciaEditDto GetProvinciaPorId(int? id);
        //void Borrar(int? id);
        bool Existe(Cliente cliente);

    }
}
