using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.ViewModels.Provincia;
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
    public class ProvinciasController : Controller
    {
        private readonly IServiciosProvincias _servicio;
        private readonly IMapper _mapper;
        public ProvinciasController(IServiciosProvincias servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();/*AutoMapperConfig.Mapper;*/
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

        [HttpGet]
        public ActionResult Delete(int? id) //int? id: en caso de que me pasen un id null
        {
            if (id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //en caso de que el id que me pasen no sea null, AHORA lo que debo mirar 
            //es que EXISTA el id que deba Borrar.
            ProvinciaEditDto provinciaDto = _servicio.GetProvinciaPorId(id);

            if (provinciaDto == null)
            {
                return HttpNotFound("El código que identifica la Provincia No Existe!");
            }
            //De existir el id, debo mostrarlo, para asi confirmar el Borrado de la Provincia.
            //Porque debo mappear a provinciaVm(provincia ViewModel)? Porque lo voy a pasar a una vista, y a la
            //vista paso todos modelos de vistas, o sea ViewModels.
            ProvinciaEditViewModel provinciaVm = _mapper.Map<ProvinciaEditViewModel>(provinciaDto);

            return View(provinciaVm);

        }

        //Si al intentar eliminar la Provincia, Mensaje: "No se encuentra el recurso", la razon es que esta hecho el Get, 
        //pero no el Post de Eliminar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(ProvinciaEditViewModel provinciaVm) 
        {
            try
            {
                provinciaVm = _mapper.Map<ProvinciaEditViewModel>(_servicio.GetProvinciaPorId(provinciaVm.ProvinciaId));

                //El servicio se encarga de borrar, le manda al repositorio que lo haga...
                _servicio.Borrar(provinciaVm.ProvinciaId);
                //Y si esta todo bien...saco el mensaje y redirecciono 
                TempData["Msg"] = "Provincia Eliminada :(";
                return RedirectToAction("Index"); //Le digo que una vez eliminada la provincia, 
                //me mande al index del mismo, o sea Provincia, aunque tambien, si lo deseo, lo puedo
                //redirecionar a cualquier otro controlador.
            }
            catch (Exception e)
            {

                ModelState.AddModelError(String.Empty, e.Message);
                return View(provinciaVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id) 
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProvinciaEditDto provinciaDto = _servicio.GetProvinciaPorId(id);
            ProvinciaEditViewModel provinciaVm = _mapper.Map<ProvinciaEditViewModel>(provinciaDto);
            return View(provinciaVm);
        }

        //Si al intentar editar la Provincia, Mensaje: "No se encuentra el recurso", la razon es que esta hecho el Get, 
        //pero no el Post de Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProvinciaEditViewModel provinciaVm) 
        {
            //Que es lo primero que debo validar al comienzo, cuand recibo una Provincia para Editar?
            //Primero debo ver que el Modelo sea Valido
            //Para que sirve hacer el !ModelState.IsValid? por ejemplo, si quiero editar, y resulta que donde aparecia el 
            //NombreProvincia, se borro, y mando algo en blanco, con la datanotacion, va a fijarse que el modelo
            //no es valido, y va a volver por este lado.
            if (!ModelState.IsValid)
            {
                return View(provinciaVm);
            }
            ProvinciaEditDto provinciaDto = _mapper.Map<ProvinciaEditDto>(provinciaVm);
            //si el modelo es valido, debo ver si el objeto existe
            if (_servicio.Existe(provinciaDto))//En "ActionResult Edit(ProvinciaEditViewModel provinciaVm)" es un ViewModel,
                                   //y aca en Existe es un ProvinciaEditDto, entonces, antes debo mapearlo, para asi pasarlo, 
                                   //entonces queda: ProvinciaEditDto provinciaDto = _mapper.Map<ProvinciaEditDto>(provinciaVm);

            {
                ModelState.AddModelError(string.Empty,"Provincia repetida...");
                return View(provinciaVm);
            }
            try
            {
                _servicio.Guardar(provinciaDto);
                TempData["Msg"] = "Provincia Editada :)";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty,e.Message);
                return View(provinciaVm);
            }
        }
    }
}