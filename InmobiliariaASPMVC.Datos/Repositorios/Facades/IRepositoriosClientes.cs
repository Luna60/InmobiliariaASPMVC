using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
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

    }
}
