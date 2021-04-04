using AutoMapper;
using InmobiliariaASPMVC.Entidades.ViewModels.Cliente;
using InmobiliariaASPMVC.Entidades.ViewModels.Localidad;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoDocumento;
using InmobiliariaASPMVC.Servicios.Servicios;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System.Collections.Generic;
using System.Web.Mvc;
using System;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;


namespace InmobiliariaASPMVC.Web.Controllers
{
    public class ClientesController : Controller
    {
        private readonly IServiciosClientes _servicio;
        private readonly IServiciosProvincias _servicioProvincia;
        private readonly IServicioLocalidades _servicioLocalidad;
        private readonly ServiciosTiposDocumentos _servicioTipoDocumento;

        private readonly IMapper _mapper;

        public ClientesController(IServiciosClientes servicio, IServiciosProvincias servicioProvincia, 
            IServicioLocalidades servicioLocalidad, ServiciosTiposDocumentos servicioTipoDocumento)
        {
            _servicio = servicio;
            _servicioProvincia = servicioProvincia;
            _servicioLocalidad = servicioLocalidad;
            _servicioTipoDocumento = servicioTipoDocumento;

            _mapper = Mapeador.Mapeador.CrearMapper();/*AutoMapperConfig.Mapper;*/
        }


        // GET: Clientes
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<ClienteListViewModel>>(listaDto);
            return View(listaVm);
        }

        //Crear Cliente
        [HttpGet]
        public ActionResult Create()
        {
            ClienteEditViewModel clienteVm = new ClienteEditViewModel
            {
                Provincia = _mapper.Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista()),
                Localidad = _mapper.Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista()),
                TipoDocumento = _mapper.Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista())

            };
            return View(clienteVm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteEditViewModel clienteEditVm)
        {
            if (!ModelState.IsValid)
            {

                clienteEditVm.Localidad = _mapper
                .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista());

                clienteEditVm.Provincia = _mapper
                .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                clienteEditVm.TipoDocumento = _mapper
                .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista());

                return View(clienteEditVm);
            }

            ClienteEditDto clienteDto = _mapper.Map<ClienteEditDto>(clienteEditVm);
            if (_servicio.Existe(clienteDto))
            {
                ModelState.AddModelError(string.Empty, "Cliente existente :/ ");

                clienteEditVm.Localidad = _mapper
                .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista());

                clienteEditVm.Provincia = _mapper
                .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                clienteEditVm.TipoDocumento = _mapper
                .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista());


                return View(clienteEditVm);

            }

            try
            {
                _servicio.Guardar(clienteDto);
                TempData["Msg"] = "Cliente agregado :) ";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);

                clienteEditVm.Localidad = _mapper
                .Map<List<LocalidadListViewModel>>(_servicioLocalidad.GetLista());

                clienteEditVm.Provincia = _mapper
                .Map<List<ProvinciaListViewModel>>(_servicioProvincia.GetLista());

                clienteEditVm.TipoDocumento = _mapper
                .Map<List<TipoDocumentoListViewModel>>(_servicioTipoDocumento.GetLista());

                return View(clienteEditVm);

            }
        }

    }
}