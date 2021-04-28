using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Venta;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositoriosVentas : IRepositoriosVentas
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositoriosVentas(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }

        public List<VentaListDto> GetLista()
        {
            try
            {
                //var venta = _context.Ventas
                //    .Include(v=>v.ItemsVentas)
                //    .SingleOrDefault(v => v.VentaId == ventaId);
                var ventas = _context.Ventas
                    .Select(nv => new VentaListDto()
                    {
                        VentaId = nv.VentaId,
                        Cliente = nv.Cliente.Apellido,
                        FechaVenta = nv.FechaVenta,
                        Total = nv.Total
                    }).ToList();

                return ventas;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public VentaListDto GetVentaPorId(int ventaId)
        {
            try
            {
                //var venta = _context.Ventas
                //    .Include(v=>v.ItemsVentas)
                //    .SingleOrDefault(v => v.VentaId == ventaId);
                var venta = _context.Ventas
                    .Select(nv => new VentaListDto()
                    {
                        VentaId = nv.VentaId,
                        Cliente = nv.Cliente.Apellido,
                        FechaVenta = nv.FechaVenta,
                        Total = nv.Total
                    }).SingleOrDefault(v => v.VentaId == ventaId);

                return venta;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(Venta venta)
        {
            try
            {
                if (venta.VentaId == 0)
                {
                    _context.Ventas.Add(venta);
                }
                else
                {
                    var ventaInDb = _context.Ventas.SingleOrDefault(v => v.VentaId == venta.VentaId);
                    ventaInDb.ClienteId = venta.ClienteId;
                    ventaInDb.FechaVenta = venta.FechaVenta;
                    ventaInDb.Total = venta.Total;
                    _context.Entry(ventaInDb).State = EntityState.Modified;
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }

        }
    }
}
