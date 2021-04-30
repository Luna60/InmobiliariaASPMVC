using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios
{
    public class ServiciosPropiedades : IServiciosPropiedades
    {
        private readonly IRepositoriosPropiedades _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosPropiedades(IRepositoriosPropiedades repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;

        }

        public void Borrar(int PropiedadId)
        {
            try
            {
                _repositorio.Borrar(PropiedadId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(PropiedadEditDto propiedadEditDto)
        {
            try
            {
                Propiedad propiedad = _mapper.Map<Propiedad>(propiedadEditDto);
                return _repositorio.Existe(propiedad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<PropiedadListDto> GetLista(string tipoPropiedad)
        {
            try
            {
                return _repositorio.GetLista(tipoPropiedad);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }


        public PropiedadEditDto GetPropiedadPorId(int? id)
        {
            try
            {
                return _repositorio.GetPropiedadPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(PropiedadEditDto propiedadDto)
        {
            try
            {
                Propiedad propiedad = _mapper.Map<Propiedad>(propiedadDto);
                _repositorio.Guardar(propiedad);
                _unitOfWork.Save();
                propiedadDto.PropiedadId = propiedad.PropiedadId;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
