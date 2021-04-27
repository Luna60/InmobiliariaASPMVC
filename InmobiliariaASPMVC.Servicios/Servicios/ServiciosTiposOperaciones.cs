using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Entidades.Entidades;
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

        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(TipoOperacionEditDto tipoOperacion)
        {
            try
            {
                TipoOperacion tipoO = _mapper.Map<TipoOperacion>(tipoOperacion);
                return _repositorio.Existe(tipoO);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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

        public void Guardar(TipoOperacionEditDto tipoOperacion)
        {
            try
            {
                TipoOperacion tipoO = _mapper.Map<TipoOperacion>(tipoOperacion);
                _repositorio.Guardar(tipoO);
                _unitOfWork.Save();
                tipoOperacion.TipoOperacionId = tipoO.TipoOperacionId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
