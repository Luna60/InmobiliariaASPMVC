using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
//using System.Data.Entity.Core.Objects.DataClasses;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositorioLocalidades : IRepositorioLocalidades
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioLocalidades(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }
        public List<LocalidadListDto> GetLista()
        {
            try
            {
                var listaDto = _context.Localidades.Include(l => l.Provincia)
                    .Select(l => new LocalidadListDto
                    {
                        LocalidadId = l.LocalidadId,
                        NombreLocalidad = l.NombreLocalidad,
                        Provincia = l.Provincia.NombreProvincia
                    }).ToList();
                return listaDto;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer las Localidades");
            }
        }
    }
}
