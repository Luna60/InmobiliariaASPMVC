using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios
{
    public class ServiciosTiposOperaciones : IServiciosTiposOperaciones
    {
        private readonly IRepositoriosTiposOperaciones _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public ServiciosTiposOperaciones(IRepositoriosTiposOperaciones repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;

        }

        public List<TipoOperacionListDto> GetLista()
        {
            try
            {
                return _repositorio.GetLista();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public TipoOperacionEditDto GetTipoOperacionPorId(int? id)
        {
            try
            {
                return _repositorio.GetTipoOperacionPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }



    }
}
