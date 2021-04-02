using AutoMapper;
using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
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
        public List<PropiedadListDto> GetLista()
        {
            throw new NotImplementedException();
        }
    }
}
