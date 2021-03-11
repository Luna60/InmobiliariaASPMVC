using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using InmobiliariaASPMVC.Servicios.Servicios;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace InmobiliariaASPMVC.Web.Controllers
{
    public class ProvinciasController : Controller
    {
        private readonly IServiciosProvincias _servicio;
        private readonly IMapper _mapper;
        public ProvinciasController()
        {
            _servicio = new ServiciosProvincias();
            _mapper = AutoMapperConfig.Mapper;
        }
        // GET: Provincia
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<ProvinciaListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create() 
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//El Create va a recibir un tipo de dato EditViewModel
        public ActionResult Create(ProvinciaEditViewModel provinciaVm) 
        {//Primero debo ver si es valido
            if (!ModelState.IsValid)
            {
                //como no es valido, retorna View(provinciaVm)
                return View(provinciaVm);
            }
            //cuando confirmo que ES Valido
            //Ahora veo que ese dato no exista ya en la tabla, pero este es un ViewModel, lo debo pasar a 
            //ProvinciaListDto, porque debo pasarlo al servicio, voy al Capa Mapeador >> MappingProfile, y pongo
            //.ReverseMap(); en CreateMap<ProvinciaListDto, ProvinciaListViewModel>(), para poder ir de un lado a otro.
            ProvinciaEditDto provinciaDto = _mapper.Map<ProvinciaEditDto>(provinciaVm);//es ProvinciaEditDto, 
            //para mantener la linea de la que vengo, vengo editando
            if (_servicio.Existe(provinciaDto))
            {
                ModelState.AddModelError(string.Empty,"Provincia ya Existente...");
                return View(provinciaVm);
            }
            try
            {
                _servicio.Guardar(provinciaDto);
                TempData["Msg"] = "Provincia Agregada :)";
                return RedirectToAction("Index");//Con RedirectToAction, le digo que una vez que guarde la Provincia,
                //me dirija a la vista Index del mismo controlador, o sea Provincia.
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(provinciaVm);
            }
        }
    }
}