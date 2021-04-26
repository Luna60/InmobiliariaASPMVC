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
        List<ClienteListDto> GetLista(string provincia);
        void Guardar(Cliente cliente);
        ClienteEditDto GetClientePorId(int? id);
        void Borrar(int ClienteId);
        bool Existe(Cliente Cliente);
        //List<ClienteListDto> GetLista();

    }
}
