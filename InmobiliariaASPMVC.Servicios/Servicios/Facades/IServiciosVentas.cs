using InmobiliariaASPMVC.Entidades.DTOs.Venta;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios.Facades
{
    public interface IServiciosVentas
    {
        void Guardar(VentaEditDto ventaDto);
        VentaListDto GetVentaPorId(int ventaId);
        List<VentaListDto> GetLista();

    }
}
