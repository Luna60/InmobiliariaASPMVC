using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Venta;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios
{
    public class ServiciosVentas : IServiciosVentas
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IRepositoriosVentas _repositorio;
        private readonly IRepositoriosClientes _repositorioCliente;

        private readonly IRepositoriosItemVentas _repositorioItems;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosVentas(InmobiliariaDbContext context, IRepositoriosVentas repositorio,
            IRepositoriosClientes repositorioCliente,
            IRepositoriosItemVentas repositorioItems, IUnitOfWork unitOfWork)
        {
            _context = context;
            _repositorio = repositorio;
            _repositorioCliente = repositorioCliente;
            _repositorioItems = repositorioItems;
            _unitOfWork = unitOfWork;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }

        public ServiciosVentas(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        public List<VentaListDto> GetLista()
        {
            try
            {
                var ventas = _repositorio.GetLista();
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
                var venta = _repositorio.GetVentaPorId(ventaId);
                venta.ItemVentas = _repositorioItems.GetLista(ventaId);
                return venta;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public void Guardar(VentaEditDto ventaDto)
        {
            Venta venta = _mapper.Map<Venta>(ventaDto);
            using (var tran = _context.Database.BeginTransaction())
            {
                try
                {
                    var venta1 = new Venta()
                    {
                        VentaId = venta.VentaId,
                        Cliente = venta.Cliente,
                        FechaVenta = venta.FechaVenta,
                        //Total = venta.Total
                    };
                    _repositorio.Guardar(venta1);
                    _unitOfWork.Save();
                    foreach (var item in venta.ItemVentas)
                    {
                        var item1 = new ItemVenta()
                        {
                            ItemVentaId = item.ItemVentaId,
                            VentaId = venta1.VentaId,
                            PropiedadId = item.Propiedad.PropiedadId,
                            PrecioUnitario = item.PrecioUnitario,
                            Total = item.Total
                        };


                        _repositorioItems.Guardar(item1);

                    }
                    _unitOfWork.Save();
                    tran.Commit();
                    ventaDto.VentaId = venta1.VentaId;
                }
                catch (Exception e)
                {
                    tran.Rollback();
                    throw new Exception(e.Message);

                }
            }

        }
    }
}
