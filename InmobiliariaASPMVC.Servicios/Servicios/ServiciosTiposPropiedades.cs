using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios
{
    public class ServiciosTiposPropiedades: IServiciosTiposPropiedades
    {
        private readonly IRepositoriosTiposPropiedades _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public ServiciosTiposPropiedades(IRepositoriosTiposPropiedades repositorio, IUnitOfWork unitOfWork)
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

        public bool Existe(TipoPropiedadEditDto tipoPropiedad)
        {
            try
            {
                TipoPropiedad tipoP = _mapper.Map<TipoPropiedad>(tipoPropiedad);
                return _repositorio.Existe(tipoP);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<TipoPropiedadListDto> GetLista()
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

        public TipoPropiedadEditDto GetTipoPropiedadPorId(int? id)
        {
            try
            {
                return _repositorio.GetTipoPropiedadPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(TipoPropiedadEditDto tipoPropiedad)
        {
            try
            {
                TipoPropiedad tipoP = _mapper.Map<TipoPropiedad>(tipoPropiedad);
                _repositorio.Guardar(tipoP);
                _unitOfWork.Save();
                tipoPropiedad.TipoPropiedadId = tipoP.TipoPropiedadId;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);

            }
        }
    }
}
