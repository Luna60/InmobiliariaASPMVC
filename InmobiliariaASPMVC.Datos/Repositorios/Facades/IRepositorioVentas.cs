using InmobiliariaASPMVC.Entidades.DTOs.Venta;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioVentas
    {
        void Guardar(Venta venta);
        VentaListDto GetVentaPorId(int ventaId);
        List<VentaListDto> GetLista();

    }
}
