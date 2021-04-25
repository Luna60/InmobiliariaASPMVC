using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.Entidades;
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
        private readonly IRepositoriosClientes _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public ServiciosClientes(IRepositoriosClientes repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;

        }

        public void Borrar(int ClienteId)
        {
            try
            {
                _repositorio.Borrar(ClienteId);
                _unitOfWork.Save();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool Existe(ClienteEditDto clienteEditDto)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteEditDto);
                return _repositorio.Existe(cliente);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public ClienteEditDto GetClientePorId(int? id)
        {
            try
            {
                return _repositorio.GetClientePorId(id);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
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

        public void Guardar(ClienteEditDto clienteDto)
        {
            try
            {
                Cliente cliente = _mapper.Map<Cliente>(clienteDto);
                _repositorio.Guardar(cliente);
                _unitOfWork.Save();
                clienteDto.ClienteId = cliente.ClienteId;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
