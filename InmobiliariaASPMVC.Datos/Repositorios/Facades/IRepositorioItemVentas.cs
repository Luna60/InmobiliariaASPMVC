using InmobiliariaASPMVC.Entidades.DTOs.ItemVenta;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios.Facades
{
    public interface IRepositorioItemVentas
    {
        void Guardar(ItemVenta itemVenta);
        List<ItemVentaListDto> GetLista(int ventaId);

    }
}
