using AutoMapper;
using InmobiliariaASPMVC.Entidades.ViewModels.Cliente;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InmobiliariaASPMVC.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IServiciosClientes _servicio;
        private readonly IMapper _mapper;

        public ClientesController(IServiciosClientes servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();/*AutoMapperConfig.Mapper;*/
        }


        // GET: Clientes
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<ClienteListViewModel>>(listaDto);
            return View(listaVm);
        }
    }
}