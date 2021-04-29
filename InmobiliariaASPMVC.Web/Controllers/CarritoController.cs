using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.DTOs.ItemVenta;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Entidades.DTOs.Venta;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Entidades.ViewModels.Carrito;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Header;

namespace InmobiliariaASPMVC.Web.Controllers
{
    public class CarritoController : Controller
    {
        private readonly IServiciosPropiedades _servicioPropiedad;
        private readonly IServiciosClientes _servicioCliente;
        private readonly IServiciosTiposPropiedades _servicioTipoPropiedad;

        private readonly IServiciosVentas _servicio;
        private IMapper _mapper;
        public ClienteListDto cliente;
        //public VentaListDto Total;

        public CarritoController(IServiciosClientes servicioCliente,
            IServiciosTiposPropiedades servicioTipoPropiedad,
            IServiciosPropiedades servicioPropiedad, IServiciosVentas servicio)
        {
            _servicioPropiedad = servicioPropiedad;
            _servicioCliente = servicioCliente;
            _servicioTipoPropiedad = servicioTipoPropiedad;

            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        // GET: Carrito
        public ActionResult Index(Carrito carrito, string returnUrl)
        {
            List<ItemCarritoListViewModel> listaItems = _mapper.Map<List<ItemCarritoListViewModel>>(carrito.GetItems());
            return View(new CarritoListViewModel
            {
                Items = listaItems,
                ReturnUrl = returnUrl
            });
        }

        public ActionResult AddToCart(Carrito carrito, int propiedadId, string returnUrl)
        {
            PropiedadEditDto propiedadDto = _servicioPropiedad.GetPropiedadPorId(propiedadId);
            if (propiedadDto != null)
            {
                Propiedad propiedad = _mapper.Map<Propiedad>(propiedadDto);
                carrito.AgregarAlCarrito(propiedad, 1);
            }
            return RedirectToAction("Index", new { returnUrl });
        }


        public ActionResult RemoveFromCart(Carrito carrito, int propiedadId, string returnUrl)
        {
            Propiedad propiedad = _mapper.Map<Propiedad>(_servicioPropiedad.GetPropiedadPorId(propiedadId));
            if (propiedad != null)
            {
                carrito.EliminarDelCarrito(propiedad);
            }

            return RedirectToAction("Index", new { returnUrl });

        }




        public PartialViewResult Summary(Carrito carrito)
        {
            return PartialView(carrito);
        }


        public ActionResult CheckOut(Carrito carrito)
        {
            if (carrito.GetItems().Count == 0)
            {
                ModelState.AddModelError(string.Empty, "No tiene compras Realizadas!!!");
            }

            var carritoVm = _mapper.Map<CarritoListViewModel>(carrito);

            return View(carritoVm);
        }

        public ActionResult CancelarPedido(Carrito carrito)
        {
            carrito.VaciarCarrito();
            return RedirectToAction("Index", "Propiedades");
        }


        public ActionResult ConfirmarPedido(Carrito carrito)
        {
            try
            {
                List<ItemVentaEditDto> listaItems = new List<ItemVentaEditDto>();
                foreach (var item in carrito.listaItems)
                {
                    ItemVentaEditDto itemDto = new ItemVentaEditDto
                    {
                        Propiedad = _mapper.Map<PropiedadListDto>(item.Propiedad),
                        PrecioUnitario = item.PrecioUni

                    };
                    listaItems.Add(itemDto);
                }
                VentaEditDto ventaEditDto = new VentaEditDto
                {
                    FechaVenta = DateTime.Now,
                    Cliente = _mapper.Map<ClienteListDto>(cliente),

                    //Total = decimal.Parse(Total),
                    ItemVentas = listaItems

                };
                _servicio.Guardar(ventaEditDto);
                ViewBag.VentaId = ventaEditDto.VentaId;
                carrito.VaciarCarrito();
                return View("VentaGuardada");

            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
            }

            return View("ErrorAlProcesarPedido");
        }

    }
}