using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Net;
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
        public ActionResult Index(string provincia)
        {
            var listaDto = _servicio.GetLista(provincia);
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

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocalidadEditDto localidadDto = _servicio.GetLocalidadPorId(id);
            if (localidadDto == null)
            {
                return HttpNotFound(" Localidad no encontrada :/ ");
            }
            LocalidadEditViewModel localidadVm = _mapper.Map<LocalidadEditViewModel>(localidadDto);
            localidadVm.Provincia = _mapper
                .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());
            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocalidadEditViewModel localidadVm)
        {
            if (!ModelState.IsValid)
            {
                localidadVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                return View(localidadVm);
            }

            LocalidadEditDto localidadDto = _mapper.Map<LocalidadEditDto>(localidadVm);
            if (_servicio.Existe(localidadDto))
            {
                ModelState.AddModelError(string.Empty, " Localidad existente :/ ");
                localidadVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                return View(localidadVm);

            }

            try
            {
                _servicio.Guardar(localidadDto);
                TempData["Msg"] = "Localidad editada :) ";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                localidadVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                return View(localidadVm);

            }

        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            LocalidadListDto localidadDto = _mapper.Map<LocalidadListDto>(_servicio.GetLocalidadPorId(id));

            if (localidadDto == null)
            {
                return HttpNotFound(" Localidad inexistente :/ ");
            }

            LocalidadListViewModel localidadVm = _mapper.Map<LocalidadListViewModel>(localidadDto);

            return View(localidadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LocalidadListViewModel localidadVm)
        {
            try
            {
                LocalidadListDto localidadDto = _mapper
                    .Map<LocalidadListDto>(_servicio.GetLocalidadPorId(localidadVm.LocalidadId));

                localidadVm = _mapper.Map<LocalidadListViewModel>(localidadDto);

                _servicio.Borrar(localidadVm.LocalidadId);
                TempData["Msg"] = "Registro borrado :) ";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(localidadVm);
            }
        }


    }
}