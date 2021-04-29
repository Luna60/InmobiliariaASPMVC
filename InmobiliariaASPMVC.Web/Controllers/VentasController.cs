using AutoMapper;
using InmobiliariaASPMVC.Entidades.ViewModels.Venta;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InmobiliariaASPMVC.Web.Controllers
{
    public class VentasController : Controller
    {
        private readonly IServiciosVentas _servicio;

        private readonly IMapper _mapper;

        public VentasController(IServiciosVentas servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }


        // GET: Ventas
        public ActionResult Index()
        {
            var ventasDto = _servicio.GetLista();
            var ventasVm = _mapper.Map<List<VentaListViewModel>>(ventasDto);
            return View(ventasVm);
        }
    }
}