using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.ItemVenta;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositorioItemVentas : IRepositorioItemVentas
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioItemVentas(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public List<ItemVentaListDto> GetLista(int ventaId)
        {
            try
            {
                var lista = _context.ItemVentas.Include(iv => iv.Propiedad).Where(iv => iv.VentaId == ventaId).ToList();
                return _mapper.Map<List<ItemVentaListDto>>(lista);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Guardar(ItemVenta itemVenta)
        {
            if (itemVenta.ItemVentaId == 0)
            {
                _context.ItemVentas.Add(itemVenta);
            }
            else
            {
                var itemInDb = _context.ItemVentas.SingleOrDefault(iv => iv.ItemVentaId == itemVenta.ItemVentaId);
                itemInDb.Valor = itemVenta.Valor;
                //itemInDb.VentaId = itemVenta.VentaId;

                itemInDb.PropiedadId = itemVenta.PropiedadId;
                itemInDb.PrecioUnitario = itemVenta.PrecioUnitario;

                _context.Entry(itemInDb).State = EntityState.Modified;


            }
        }
    }
}
