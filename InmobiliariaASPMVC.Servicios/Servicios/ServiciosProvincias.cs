using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.Entidades;
using InmobiliariaASPMVC.Mapeador;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios
{
    public class ServiciosProvincias : IServiciosProvincias
    {
        private readonly IRepositorioProvincias _repositorio;
        private readonly IMapper _mapper;
        public ServiciosProvincias()
        {
            _repositorio = new RepositorioProvincias();
            _mapper = Mapeador.Mapeador.CrearMapper();

        }
        public void Borrar(int? id)
        {
            try
            {
                _repositorio.Borrar(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public bool Existe(ProvinciaEditDto provinciaDto)//ahora es un provinciaDto, porque lo debo pasar a la capa
            //de Datos, y ahi lo voy a pasar como una Entidad de Modelo de dominio
        {
            try
            {
                Provincia provincia = _mapper.Map<Provincia>(provinciaDto);
                return _repositorio.Existe(provincia);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<ProvinciaListDto> GetLista()
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

        public ProvinciaEditDto GetProvinciaPorId(int? id)
        {
            try
            {
                return _repositorio.GetProvinciaPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Guardar(ProvinciaEditDto provinciaDto)
        {
            try
            {
                Provincia provincia = _mapper.Map<Provincia>(provinciaDto);
                _repositorio.Guardar(provincia);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}
