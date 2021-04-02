using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositorioPropiedades
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioPropiedades(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }
        public List<PropiedadListDto> GetLista()
        {
            try
            {
                var listaDto = _context.Propiedades
                    .Include(p => p.TipoPropiedad)
                    .Include(p => p.TipoOperacion)
                    .Include(p => p.Provincia)
                    .Include(p => p.Localidad)
                    .Select(p => new PropiedadListDto
                    {
                        PropiedadId = p.PropiedadId,
                        TipoPropiedad = p.TipoPropiedad.Descripcion,
                        TipoOperacion = p.TipoOperacion.Descripcion,
                        Provincia = p.Provincia.NombreProvincia,
                        Localidad = p.Localidad.NombreLocalidad
                    }).ToList();
                return listaDto;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer las Propiedades");
            }
        }

    }
}
