using AutoMapper;
using InmobiliariaASPMVC.Entidades.ViewModels.Propiedad;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InmobiliariaASPMVC.Web.Controllers
{
    public class PropiedadesController : Controller
    {
        private readonly IServiciosPropiedades _servicio;
        private readonly IMapper _mapper;

        public PropiedadesController(IServiciosPropiedades servicios)
        {
            _servicio = servicios;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        // GET: Propiedades
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<PropiedadListViewModel>>(listaDto);
            return View(listaVm);
        }
    }
}