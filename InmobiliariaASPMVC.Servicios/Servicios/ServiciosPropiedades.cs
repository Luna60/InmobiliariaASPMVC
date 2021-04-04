﻿using AutoMapper;
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

        public List<PropiedadListDto> GetLista()
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

        public void Guardar(PropiedadEditDto propiedadDto)
        {
            throw new NotImplementedException();
        }
    }
}
