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
        List<ClienteListDto> GetLista(string provincia);
        void Guardar(ClienteEditDto clienteDto);
        bool Existe(ClienteEditDto clienteEditDto);
        ClienteEditDto GetClientePorId(int? id);
        void Borrar(int ClienteId);
        //List<ClienteListDto> GetLista();

    }
}
