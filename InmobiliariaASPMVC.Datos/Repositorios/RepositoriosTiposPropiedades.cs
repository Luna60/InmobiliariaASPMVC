using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositoriosTiposPropiedades: IRepositoriosTiposPropiedades
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositoriosTiposPropiedades(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public List<TipoPropiedadListDto> GetLista()
        {
            try
            {
                var lista = _context.TiposPropiedades.ToList();
                return _mapper.Map<List<TipoPropiedadListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al querer traer los Tipos de Propiedades");
            }
        }

        public TipoPropiedadEditDto GetTipoPropiedadPorId(int? id)
        {
            try
            {
                //El SingleOrDefault me esta devolviendo una Provincia, yo lo debo pasar a ProvinciaEditDto, 
                //Me fijo si en el MappingProfile, esta CreateMap<Provincia, ProvinciaEditDto>().ReverseMap();, de
                //estar entonces, vuelvo y... le digo que me pase de Provincia a ProvinciaEditDto, basandose en 
                //lo que le pasan en _context.Provincias.SingleOrDefault(p => p.ProvinciaId == id).

                return _mapper
                    .Map<TipoPropiedadEditDto>(_context.TiposPropiedades.SingleOrDefault(p => p.TipoPropiedadId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al querer traer el Tipo de Propiedad");
            }
        }
    }


}
