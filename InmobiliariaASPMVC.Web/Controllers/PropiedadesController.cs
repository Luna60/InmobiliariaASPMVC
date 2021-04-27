using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Entidades.ViewModels.Cliente;
using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
using InmobiliariaASPMVC.Entidades.ViewModels.Propiedad;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoOperacion;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoPropiedad;
using InmobiliariaASPMVC.Servicios.Servicios;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InmobiliariaASPMVC.Web.Controllers
{
    public class PropiedadesController : Controller
    {
        private readonly IServiciosPropiedades _servicio;
        private readonly IServiciosClientes _servicioClientes;
        private readonly IServiciosProvincias _servicioProvincia;
        private readonly IServicioLocalidades _servicioLocalidad;
        private readonly IServiciosTiposPropiedades _servicioTipoPropiedad;
        private readonly IServiciosTiposOperaciones _servicioTipoOperacion;

        private readonly IMapper _mapper;


        public PropiedadesController(IServiciosPropiedades servicio, IServiciosClientes servicioClientes, IServiciosProvincias servicioProvincia,
            IServicioLocalidades servicioLocalidad, IServiciosTiposPropiedades servicioTipoPropiedad,
            IServiciosTiposOperaciones servicioTipoOperacion)
        {
            _servicio = servicio;
            _servicioClientes = servicioClientes;

            _servicioProvincia = servicioProvincia;
            _servicioLocalidad = servicioLocalidad;
            _servicioTipoPropiedad = servicioTipoPropiedad;

            _servicioTipoOperacion = servicioTipoOperacion;

            _mapper = Mapeador.Mapeador.CrearMapper();/*AutoMapperConfig.Mapper;*/
        }



        // GET: Propiedades
        public ActionResult Index(string provincia)
        {
            var listaDto = _servicio.GetLista(provincia);
            var listaVm = _mapper.Map<List<PropiedadListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            PropiedadEditViewModel propiedadVm = new PropiedadEditViewModel
            {
                Disponible = true,
                Jardin = true,
                Garage = true,
                Cliente = _mapper
                    .Map<List<ClienteListViewModel>>(_servicioClientes.GetLista(null)),
                Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista()),
                Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null)),
                TipoPropiedad = _mapper
                    .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista()),
                TipoOperacion = _mapper
                    .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista()),


            };
            return View(propiedadVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(PropiedadEditViewModel propiedadEditVm)
        {
            if (!ModelState.IsValid)
            {
                propiedadEditVm.Cliente = _mapper
                    .Map<List<ClienteListViewModel>>(_servicioClientes.GetLista(null));

                propiedadEditVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                propiedadEditVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                propiedadEditVm.TipoPropiedad = _mapper
                    .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista());

                propiedadEditVm.TipoOperacion = _mapper
                    .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista());

                propiedadEditVm.Cliente = _mapper
                    .Map<List<ClienteListViewModel>>(_servicioClientes.GetLista(null));


                return View(propiedadEditVm);
            }

            PropiedadEditDto propiedadDto = _mapper.Map<PropiedadEditDto>(propiedadEditVm);
            if (_servicio.Existe(propiedadDto))
            {
                ModelState.AddModelError(string.Empty, "Propiedad existente...");

                propiedadEditVm.Cliente = _mapper
                    .Map<List<ClienteListViewModel>>(_servicioClientes.GetLista(null));

                propiedadEditVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                propiedadEditVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                propiedadEditVm.TipoPropiedad = _mapper
                    .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista());

                propiedadEditVm.TipoOperacion = _mapper
                    .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista());




                return View(propiedadEditVm);

            }

            try
            {
                _servicio.Guardar(propiedadDto);
                TempData["Msg"] = "Propiedad Agregada :) ";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                propiedadEditVm.Cliente = _mapper
                    .Map<List<ClienteListViewModel>>(_servicioClientes.GetLista(null));

                propiedadEditVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                propiedadEditVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                propiedadEditVm.TipoPropiedad = _mapper
                    .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista());

                propiedadEditVm.TipoOperacion = _mapper
                    .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista());



                return View(propiedadEditVm);

            }
        }


        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PropiedadEditDto propiedadDto = _servicio.GetPropiedadPorId(id);
            if (propiedadDto == null)
            {
                return HttpNotFound("Código de la Propiedad no encontrada");
            }
            PropiedadEditViewModel propiedadVm = _mapper.Map<PropiedadEditViewModel>(propiedadDto);

            propiedadVm.Cliente = _mapper
                .Map<List<ClienteListViewModel>>(_servicioClientes.GetLista(null));

            propiedadVm.Provincia = _mapper
                .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

            propiedadVm.Localidad = _mapper
                .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

            propiedadVm.TipoPropiedad = _mapper
                .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista());

            propiedadVm.TipoOperacion = _mapper
                .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista());



            return View(propiedadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(PropiedadEditViewModel propiedadVm)
        {
            if (!ModelState.IsValid)
            {

                propiedadVm.Cliente = _mapper
                    .Map<List<ClienteListViewModel>>(_servicioClientes.GetLista(null));

                propiedadVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                propiedadVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                propiedadVm.TipoPropiedad = _mapper
                    .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista());

                propiedadVm.TipoOperacion = _mapper
                    .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista());

                return View(propiedadVm);
            }

            PropiedadEditDto propiedadDto = _mapper.Map<PropiedadEditDto>(propiedadVm);
            if (_servicio.Existe(propiedadDto))
            {
                ModelState.AddModelError(string.Empty, "Propiedad existente :/ ");

                propiedadVm.Cliente = _mapper
                    .Map<List<ClienteListViewModel>>(_servicioClientes.GetLista(null));

                propiedadVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                propiedadVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                propiedadVm.TipoPropiedad = _mapper
                    .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista());

                propiedadVm.TipoOperacion = _mapper
                    .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista());




                return View(propiedadVm);

            }

            try
            {
                _servicio.Guardar(propiedadDto);
                TempData["Msg"] = "Propiedad editada :) ";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                propiedadVm.Cliente = _mapper
                    .Map<List<ClienteListViewModel>>(_servicioClientes.GetLista(null));

                propiedadVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                propiedadVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                propiedadVm.TipoPropiedad = _mapper
                    .Map<List<TipoPropiedadListViewModel>>(_servicioTipoPropiedad.GetLista());

                propiedadVm.TipoOperacion = _mapper
                    .Map<List<TipoOperacionListViewModel>>(_servicioTipoOperacion.GetLista());


                return View(propiedadVm);

            }

        }


        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            PropiedadListDto propiedadDto = _mapper.Map<PropiedadListDto>(_servicio.GetPropiedadPorId(id));
            if (propiedadDto == null)
            {
                return HttpNotFound("Código de la Propiedad inexistente...");
            }

            PropiedadListViewModel propiedadVm = _mapper.Map<PropiedadListViewModel>(propiedadDto);
            return View(propiedadVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(PropiedadListViewModel propiedadVm)
        {
            try
            {
                PropiedadListDto propiedadDto = _mapper
                    .Map<PropiedadListDto>(_servicio.GetPropiedadPorId(propiedadVm.PropiedadId));
                propiedadVm = _mapper.Map<PropiedadListViewModel>(propiedadDto);

                _servicio.Borrar(propiedadVm.PropiedadId);
                TempData["Msg"] = "Registro borrado :) ";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(propiedadVm);
            }
        }


    }
}