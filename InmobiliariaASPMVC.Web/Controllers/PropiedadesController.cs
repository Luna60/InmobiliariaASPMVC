//using AutoMapper;
//using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
//using InmobiliariaASPMVC.Entidades.ViewModels.Cliente;
//using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
//using InmobiliariaASPMVC.Entidades.ViewModels.Propiedad;
//using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
//using InmobiliariaASPMVC.Entidades.ViewModels.TipoOperacion;
//using InmobiliariaASPMVC.Entidades.ViewModels.TipoPropiedad;
//using InmobiliariaASPMVC.Servicios.Servicios.Facades;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace InmobiliariaASPMVC.Web.Controllers
//{
//    public class PropiedadesController : Controller
//    {
//        private readonly IServiciosPropiedades _servicio;
//        private readonly IServiciosClientes _servicioCliente;
//        private readonly IServiciosTiposPropiedades _servicioTipoPropiedad;
//        private readonly IServiciosTiposOperaciones _servicioTipoOperacion;
//        private readonly IServicioLocalidades _servicioLocalidad;
//        private readonly IServiciosProvincias _servicioProvincia;

//        private readonly IMapper _mapper;

//        public PropiedadesController(IServiciosPropiedades servicios,
//            IServiciosClientes servicioCliente,
//            IServiciosTiposPropiedades servicioTipoPropiedad,
//            IServiciosTiposOperaciones servicioTipoOperacion,
//            IServicioLocalidades servicioLocalidad,
//            IServiciosProvincias servicioProvincia)
//        {
//            _servicio = servicios;
//            _servicioCliente = servicioCliente;
//            _servicioTipoPropiedad = servicioTipoPropiedad;
//            _servicioTipoOperacion = servicioTipoOperacion;
//            _servicioProvincia = servicioProvincia;
//            _servicioLocalidad = servicioLocalidad;

//            _mapper = Mapeador.Mapeador.CrearMapper();
//        }
//        // GET: Propiedades
//        public ActionResult Index()
//        {
//            var listaDto = _servicio.GetLista();
//            var listaVm = _mapper.Map<List<PropiedadListViewModel>>(listaDto);
//            return View(listaVm);
//        }

//        //Crear Propiedad
//        [HttpGet]
//        public ActionResult Create()
//        {
//            PropiedadEditViewModel propiedadVm = new PropiedadEditViewModel
//            {
//                Disponible = true,
//                Jardin = true,
//                Garage = true,
//                Cliente = _mapper.Map<List<ClienteListViewModel>>(_servicioCliente.GetLista()),
//                TipoPropiedad = _mapper.Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista()),
//                TipoOperacion = _mapper.Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista()),
//                Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista()),
//                Localidad = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista()),

//            };
//            return View(propiedadVm);
//        }


//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Create(PropiedadEditViewModel propiedadEditVm)
//        {
//            if (!ModelState.IsValid)
//            {
//                propiedadEditVm.Cliente = _mapper
//               .Map<List<ClienteListViewModel>>(_servicioCliente.GetLista());

//                propiedadEditVm.TipoPropiedad = _mapper
//                .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista());

//                propiedadEditVm.TipoOperacion = _mapper
//                .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista());

//                propiedadEditVm.Localidad = _mapper
//                .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista());

//                propiedadEditVm.Provincia = _mapper
//                .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

//                return View(propiedadEditVm);
//            }

//            PropiedadEditDto propiedadDto = _mapper.Map<PropiedadEditDto>(propiedadEditVm);
//            if (_servicio.Existe(propiedadDto))
//            {
//                ModelState.AddModelError(string.Empty, "Propiedad existente...");

//                propiedadEditVm.Cliente = _mapper
//               .Map<List<ClienteListViewModel>>(_servicioCliente.GetLista());

//                propiedadEditVm.TipoPropiedad = _mapper
//                .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista());

//                propiedadEditVm.TipoOperacion = _mapper
//                .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista());

//                propiedadEditVm.Localidad = _mapper
//                .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista());

//                propiedadEditVm.Provincia = _mapper
//                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

//                return View(propiedadEditVm);

//            }

//            try
//            {
//                _servicio.Guardar(propiedadDto);
//                TempData["Msg"] = "Propiedad agregada...";
//                return RedirectToAction("Index");
//            }
//            catch (Exception e)
//            {
//                ModelState.AddModelError(string.Empty, e.Message);

//                propiedadEditVm.Cliente = _mapper
//                .Map<List<ClienteListViewModel>>(_servicioCliente.GetLista());

//                propiedadEditVm.TipoPropiedad = _mapper
//                .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista());

//                propiedadEditVm.TipoOperacion = _mapper
//                .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista());

//                propiedadEditVm.Localidad = _mapper
//                .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista());


//                propiedadEditVm.Provincia = _mapper
//                .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

//                return View(propiedadEditVm);

//            }
//        }
//    }
//}