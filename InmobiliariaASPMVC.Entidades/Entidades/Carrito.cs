using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Entidades.Entidades
{
    public class Carrito
    {
        public List<ItemCarrito> listaItems { get; set; } = new List<ItemCarrito>();

        public List<ItemCarrito> GetItems()
        {
            return listaItems;
        }
        public void AgregarAlCarrito(Propiedad propiedad)
        {
            var item = listaItems.SingleOrDefault(i => i.Propiedad.PropiedadId == propiedad.PropiedadId);
            if (item == null)
            {
                listaItems.Add(new ItemCarrito
                {
                    Propiedad = propiedad,
                    //Cantidad = cantidad
                });
            }
            else
            {
                //item.Cantidad++;
            }
        }

        public void EliminarDelCarrito(Propiedad propiedad)
        {
            listaItems.RemoveAll(i => i.Propiedad.PropiedadId == propiedad.PropiedadId);
        }

        public decimal TotalCarrito()
        {
            return listaItems.Sum(i => i.PrecioUni + i.Propiedad.CostoOperacion);//(i => i.Cantidad * i.Producto.Precio);
        }

        public void VaciarCarrito()
        {
            listaItems.Clear();
        }

    }
}
