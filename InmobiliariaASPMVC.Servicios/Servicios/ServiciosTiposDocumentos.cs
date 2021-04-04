using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Servicios.Servicios
{
    public class ServiciosTiposDocumentos : IServiciosTiposDocumentos
    {
        private readonly IRepositoriosTiposDocumentos _repositorio;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;


        public ServiciosTiposDocumentos(IRepositoriosTiposDocumentos repositorio, IUnitOfWork unitOfWork)
        {
            _repositorio = repositorio;
            _mapper = Mapeador.Mapeador.CrearMapper();
            _unitOfWork = unitOfWork;

        }

        public TipoDocumentoEditDto GetipoDocumentoPorId(int? id)
        {
            try
            {
                return _repositorio.GetTipoDocumentoPorId(id);
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public List<TipoDocumentoListDto> GetLista()
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
