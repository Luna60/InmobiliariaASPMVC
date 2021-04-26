using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Entidades.ViewModels.Cliente;
using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoDocumento;
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
    public class ClientesController : Controller
    {

        private readonly IServiciosClientes _servicio;
        private readonly IServiciosProvincias _servicioProvincia;
        private readonly IServicioLocalidades _servicioLocalidad;
        private readonly IServiciosTiposDocumentos _servicioTipoDocumento;

        private readonly IMapper _mapper;


        public ClientesController(IServiciosClientes servicio, IServiciosProvincias servicioProvincia,
            IServicioLocalidades servicioLocalidad, IServiciosTiposDocumentos servicioTipoDocumento)
        {
            _servicio = servicio;
            _servicioProvincia = servicioProvincia;
            _servicioLocalidad = servicioLocalidad;
            _servicioTipoDocumento = servicioTipoDocumento;

            _mapper = Mapeador.Mapeador.CrearMapper();/*AutoMapperConfig.Mapper;*/
        }



        // GET: Clientes
        public ActionResult Index(string provincia)
        {
            var listaDto = _servicio.GetLista(provincia);
            var listaVm = _mapper.Map<List<ClienteListViewModel>>(listaDto);
            return View(listaVm);
        }

        [HttpGet]
        public ActionResult Create()
        {
            ClienteEditViewModel clienteVm = new ClienteEditViewModel
            {
                //Activo = true,
                Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista()),
                Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null)),
                TipoDocumento = _mapper
                    .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista())


            };
            return View(clienteVm);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEditViewModel clienteEditVm)
        {
            if (!ModelState.IsValid)
            {
                clienteEditVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                clienteEditVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                clienteEditVm.TipoDocumento = _mapper
                    .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista());


                return View(clienteEditVm);
            }

            ClienteEditDto clienteDto = _mapper.Map<ClienteEditDto>(clienteEditVm);
            if (_servicio.Existe(clienteDto))
            {
                ModelState.AddModelError(string.Empty, "Cliente existente...");

                clienteEditVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                clienteEditVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                clienteEditVm.TipoDocumento = _mapper
                    .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista());


                return View(clienteEditVm);

            }

            try
            {
                _servicio.Guardar(clienteDto);
                TempData["Msg"] = "Cliente Agregado :) ";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                clienteEditVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                clienteEditVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                clienteEditVm.TipoDocumento = _mapper
                    .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista());

                return View(clienteEditVm);

            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteEditDto clienteDto = _servicio.GetClientePorId(id);
            if (clienteDto == null)
            {
                return HttpNotFound("Código del Cliente no encontrado");
            }
            ClienteEditViewModel clienteVm = _mapper.Map<ClienteEditViewModel>(clienteDto);

            clienteVm.Provincia = _mapper
                .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

            clienteVm.Localidad = _mapper
                .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

            clienteVm.TipoDocumento = _mapper
                .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista());


            return View(clienteVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteEditViewModel clienteVm)
        {
            if (!ModelState.IsValid)
            {
                clienteVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                clienteVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                clienteVm.TipoDocumento = _mapper
                    .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista());


                return View(clienteVm);
            }

            ClienteEditDto clienteDto = _mapper.Map<ClienteEditDto>(clienteVm);
            if (_servicio.Existe(clienteDto))
            {
                ModelState.AddModelError(string.Empty, "Cliente existente :/ ");

                clienteVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                clienteVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                clienteVm.TipoDocumento = _mapper
                    .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista());



                return View(clienteVm);

            }

            try
            {
                _servicio.Guardar(clienteDto);
                TempData["Msg"] = "Cliente editado :) ";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                clienteVm.Provincia = _mapper
                    .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                clienteVm.Localidad = _mapper
                    .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista(null));

                clienteVm.TipoDocumento = _mapper
                    .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista());

                return View(clienteVm);

            }

        }

        [HttpGet]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            ClienteListDto clienteDto = _mapper.Map<ClienteListDto>(_servicio.GetClientePorId(id));
            if (clienteDto == null)
            {
                return HttpNotFound("Código del Cliente inexistente...");
            }

            ClienteListViewModel clienteVm = _mapper.Map<ClienteListViewModel>(clienteDto);
            return View(clienteVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ClienteListViewModel clienteVm)
        {
            try
            {
                ClienteListDto clienteDto = _mapper
                    .Map<ClienteListDto>(_servicio.GetClientePorId(clienteVm.ClienteId));
                clienteVm = _mapper.Map<ClienteListViewModel>(clienteDto);

                _servicio.Borrar(clienteVm.ClienteId);
                TempData["Msg"] = "Registro borrado :) ";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(String.Empty, e.Message);
                return View(clienteVm);
            }
        }



    }
}