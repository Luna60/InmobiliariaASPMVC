using AutoMapper;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Entidades.ViewModels.TipoOperacion;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace InmobiliariaASPMVC.Web.Controllers
{
    public class TiposOperacionesController : Controller
    {
        private readonly IServiciosTiposOperaciones _servicio;
        private readonly IMapper _mapper;
        public TiposOperacionesController(IServiciosTiposOperaciones servicio)
        {
            _servicio = servicio;
            _mapper = Mapeador.Mapeador.CrearMapper();/*AutoMapperConfig.Mapper;*/
        }


        // GET: TiposOperaciones
        public ActionResult Index()
        {
            var listaDto = _servicio.GetLista();
            var listaVm = _mapper.Map<List<TipoOperacionListViewModel>>(listaDto);
            return View(listaVm);
        }


        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]//El Create va a recibir un tipo de dato EditViewModel
        public ActionResult Create(TipoOperacionEditViewModel tipoOpeVm)
        {//Primero debo ver si es valido
            if (!ModelState.IsValid)
            {
                //como no es valido, retorna View(provinciaVm)
                return View(tipoOpeVm);
            }
            //cuando confirmo que ES Valido
            //Ahora veo que ese dato no exista ya en la tabla, pero este es un ViewModel, lo debo pasar a 
            //ProvinciaListDto, porque debo pasarlo al servicio, voy al Capa Mapeador >> MappingProfile, y pongo
            //.ReverseMap(); en CreateMap<ProvinciaListDto, ProvinciaListViewModel>(), para poder ir de un lado a otro.
            TipoOperacionEditDto tipoOpeDto = _mapper.Map<TipoOperacionEditDto>(tipoOpeVm);//es ProvinciaEditDto, 
            //para mantener la linea de la que vengo, vengo editando
            if (_servicio.Existe(tipoOpeDto))
            {
                ModelState.AddModelError(string.Empty, "Tipo de Operacion ya Existente...");
                return View(tipoOpeVm);
            }
            try
            {
                _servicio.Guardar(tipoOpeDto);
                TempData["Msg"] = "Tipo de Operacion Agregado :)";
                return RedirectToAction("Index");//Con RedirectToAction, le digo que una vez que guarde la Provincia,
                //me dirija a la vista Index del mismo controlador, o sea Provincia.
            }
            catch (Exception e)
            {
                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoOpeVm);
            }
        }

        [HttpGet]
        public ActionResult Delete(int? id) //int? id: en caso de que me pasen un id null
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //en caso de que el id que me pasen no sea null, AHORA lo que debo mirar 
            //es que EXISTA el id que deba Borrar.
            TipoOperacionEditDto tipoOpeDto = _servicio.GetTipoOperacionPorId(id);

            if (tipoOpeDto == null)
            {
                return HttpNotFound("El código que identifica el Tipo de Operacion No Existe!");
            }
            //De existir el id, debo mostrarlo, para asi confirmar el Borrado de la Provincia.
            //Porque debo mappear a provinciaVm(provincia ViewModel)? Porque lo voy a pasar a una vista, y a la
            //vista paso todos modelos de vistas, o sea ViewModels.
            TipoOperacionEditViewModel tipoOpeVm = _mapper.Map<TipoOperacionEditViewModel>(tipoOpeDto);

            return View(tipoOpeVm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(TipoOperacionEditViewModel tipoOpeVm)
        {
            try
            {
                tipoOpeVm = _mapper.Map<TipoOperacionEditViewModel>(_servicio.GetTipoOperacionPorId(tipoOpeVm.TipoOperacionId));

                //El servicio se encarga de borrar, le manda al repositorio que lo haga...
                _servicio.Borrar(tipoOpeVm.TipoOperacionId);
                //Y si esta todo bien...saco el mensaje y redirecciono 
                TempData["Msg"] = "Tipo de Operacion Eliminado :(";
                return RedirectToAction("Index"); //Le digo que una vez eliminada la provincia, 
                //me mande al index del mismo, o sea Provincia, aunque tambien, si lo deseo, lo puedo
                //redirecionar a cualquier otro controlador.
            }
            catch (Exception e)
            {

                ModelState.AddModelError(String.Empty, e.Message);
                return View(tipoOpeVm);
            }
        }

        [HttpGet]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TipoOperacionEditDto tipoOpeDto = _servicio.GetTipoOperacionPorId(id);
            TipoOperacionEditViewModel tipoOpeVm = _mapper.Map<TipoOperacionEditViewModel>(tipoOpeDto);
            return View(tipoOpeVm);
        }

        //Si al intentar editar la Provincia, Mensaje: "No se encuentra el recurso", la razon es que esta hecho el Get, 
        //pero no el Post de Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TipoOperacionEditViewModel tipoOpeVm)
        {
            //Que es lo primero que debo validar al comienzo, cuand recibo una Provincia para Editar?
            //Primero debo ver que el Modelo sea Valido
            //Para que sirve hacer el !ModelState.IsValid? por ejemplo, si quiero editar, y resulta que donde aparecia el 
            //NombreProvincia, se borro, y mando algo en blanco, con la datanotacion, va a fijarse que el modelo
            //no es valido, y va a volver por este lado.
            if (!ModelState.IsValid)
            {
                return View(tipoOpeVm);
            }
            TipoOperacionEditDto tipoOpeDto = _mapper.Map<TipoOperacionEditDto>(tipoOpeVm);
            //si el modelo es valido, debo ver si el objeto existe
            if (_servicio.Existe(tipoOpeDto))//En "ActionResult Edit(ProvinciaEditViewModel provinciaVm)" es un ViewModel,
                                             //y aca en Existe es un ProvinciaEditDto, entonces, antes debo mapearlo, para asi pasarlo, 
                                             //entonces queda: ProvinciaEditDto provinciaDto = _mapper.Map<ProvinciaEditDto>(provinciaVm);

            {
                ModelState.AddModelError(string.Empty, "Tipo de Operacion repetido...");
                return View(tipoOpeVm);
            }
            try
            {
                _servicio.Guardar(tipoOpeDto);
                TempData["Msg"] = "Tipo de Operacion Editado :)";
                return RedirectToAction("Index");
            }
            catch (Exception e)
            {

                ModelState.AddModelError(string.Empty, e.Message);
                return View(tipoOpeVm);
            }
        }


    }
}