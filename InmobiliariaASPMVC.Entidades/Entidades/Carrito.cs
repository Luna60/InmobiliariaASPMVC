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
        public void AgregarAlCarrito(Propiedad propiedad, decimal valor)
        {
            var item = listaItems.SingleOrDefault(i => i.Propiedad.PropiedadId == propiedad.PropiedadId);
            if (item == null)
            {
                listaItems.Add(new ItemCarrito
                {
                    Propiedad = propiedad,
                    Valor = valor

                });
            }
            //else
            //{
            //    //item.Cantidad++;
            //}
        }

        public void EliminarDelCarrito(Propiedad propiedad)
        {
            listaItems.RemoveAll(i => i.Propiedad.PropiedadId == propiedad.PropiedadId);
        }

        public decimal TotalCarrito()
        {
            return listaItems.Sum(i => i.Valor + i.Propiedad.CostoOperacion);
        }

        public void VaciarCarrito()
        {
            listaItems.Clear();
        }

    }
}
