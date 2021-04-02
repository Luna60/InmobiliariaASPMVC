using AutoMapper;
using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InmobiliariaASPMVC.Web.Controllers
{
    public class LocalidadesController : Controller
    {
        private readonly IServicioLocalidades _servicio;
        private readonly IMapper _mapper;

        public LocalidadesController(IServicioLocalidades servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();/*AutoMapperConfig.Mapper;*/
        }

        // GET: Localidad
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<LocalidadListViewModel>>(listaDto);
            return View(listaVm);
        }
    }
}