using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Mapeador;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositoriosPropiedades : IRepositoriosPropiedades
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositoriosPropiedades(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }
        public List<PropiedadListDto> GetLista()
        {
            try
            {
                var listaDto = _context.Propiedades
                    .Include(p => p.Cliente)
                    .Include(p => p.TipoPropiedad)
                    .Include(p => p.TipoOperacion)
                    .Include(p => p.Localidad)
                    .Include(p => p.Provincia)
                    .Select(p => new PropiedadListDto
                    {
                        PropiedadId = p.PropiedadId,
                        Disponible = p.Disponible,
                        Cliente = p.Cliente.Apellido,
                        TipoPropiedad = p.TipoPropiedad.DescripcionTP,
                        TipoOperacion = p.TipoOperacion.DescripcionTO,
                        Localidad = p.Localidad.NombreLocalidad,
                        Provincia = p.Provincia.NombreProvincia
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
