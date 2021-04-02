﻿using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios
{
    public class ServiciosLocalidades : IServicioLocalidades
    {
        private readonly IRepositorioLocalidades _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        //public ServiciosLocalidades(IRepositorioProvincias repositorio, IUnitOfWork unitOfWork)
        //{
        //    _repositorio = repositorio;
        //    _mapper = Mapeador.Mapeador.CrearMapper();
        //    _unitOfWork = unitOfWork;

        //}

        public List<LocalidadListDto> GetLista()
        {
            throw new NotImplementedException();
        }
    }
}