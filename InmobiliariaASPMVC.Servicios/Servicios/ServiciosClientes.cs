using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios
{
    public class ServiciosClientes : IServiciosClientes
    {
        private readonly IRepositorioCliente _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosClientes(IRepositorioCliente repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;

        }

        public List<ClienteListDto> GetLista()
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

    }
}
