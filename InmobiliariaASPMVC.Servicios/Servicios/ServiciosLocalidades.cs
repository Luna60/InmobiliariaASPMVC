using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;

namespace InmobiliariaASPMVC.Servicios.Servicios
{
    public class ServiciosLocalidades : IServicioLocalidades
    {
        private readonly IRepositoriosLocalidades _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosLocalidades(IRepositoriosLocalidades repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;

        }

        public void Borrar(int provinciaVmLocalidadId)
        {
            try
            {
                _repositorio.Borrar(provinciaVmLocalidadId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(LocalidadEditDto localidadEditDto)
        {
            try
            {
                Localidad localidad = _mapper.Map<Localidad>(localidadEditDto);
                return _repositorio.Existe(localidad);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<LocalidadListDto> GetLista()
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

        public LocalidadEditDto GetLocalidadPorId(int? id)
        {
            try
            {
                return _repositorio.GetLocalidadPorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Guardar(LocalidadEditDto localidadDto)
        {
            try
            {
                Localidad localidad = _mapper.Map<Localidad>(localidadDto);
                _repositorio.Guardar(localidad);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

    }
}
