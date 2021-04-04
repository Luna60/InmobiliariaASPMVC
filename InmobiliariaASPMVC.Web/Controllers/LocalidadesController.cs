using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace InmobiliariaASPMVC.Web.Controllers
{
    public class LocalidadesController : Controller
    {
        private readonly IServicioLocalidades _servicio;
        private readonly IServiciosProvincias _servicioProvincia;

        private readonly IMapper _mapper;


        public LocalidadesController(IServicioLocalidades servicio, IServiciosProvincias servicioProvincia)
        {
            _servicio = servicio;
            _servicioProvincia = servicioProvincia;
            _mapper = Mapeador.Mapeador.CrearMapper();/*AutoMapperConfig.Mapper;*/
        }

        // GET: Localidad
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<LocalidadListViewModel>>(listaDto);
            return View(listaVm);
        }

        //Crear Localidad
        [HttpGet]
        public ActionResult Create()
        {
            LocalidadEditViewModel localidadVm = new LocalidadEditViewModel
            {
                Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista())

            };
           return View(localidadVm);


        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocalidadEditViewModel localidadEditVm)
        {
            if (!ModelState.IsValid)
            {
                localidadEditVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                return View(localidadEditVm);
            }

            LocalidadEditDto localidadDto = _mapper.Map<LocalidadEditDto>(localidadEditVm);
            if (_servicio.Existe(localidadDto))
            {
                ModelState.AddModelError(string.Empty, "Localidad existente :/ ");
                localidadEditVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                return View(localidadEditVm);

            }

            try
            {
                _servicio.Guardar(localidadDto);
                TempData["Msg"] = "Localidad agregada :) ";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                localidadEditVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                return View(localidadEditVm);

            }
        }
    }
}