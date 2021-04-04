using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios.Facades
{
    public interface IServiciosClientes
    {
        List<ClienteListDto> GetLista();
        void Guardar(ClienteEditDto clienteDto);
        bool Existe(ClienteEditDto clienteEditDto);
        //ProductoEditDto GetProductoPorId(int? id);
        //void Borrar(int tipoVmProductoId);

    }
}
