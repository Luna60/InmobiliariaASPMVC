using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.TipoPropiedad;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public void Borrar(int? id)
        {
            try
            {
                var tipoProInDb = _context.TiposPropiedades
                    .SingleOrDefault(tp => tp.TipoPropiedadId == id);
                _context.Entry(tipoProInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error al borrar un Tipo de Propiedad");
            }
        }

        public bool Existe(TipoPropiedad tipoPropiedad)
        {
            if (tipoPropiedad.TipoPropiedadId == 0)
            {
                return _context.TiposPropiedades.Any(tp => tp.DescripcionTP == tipoPropiedad.DescripcionTP);
            }

            return _context.TiposPropiedades.Any(tp =>
                tp.DescripcionTP == tipoPropiedad.DescripcionTP && tp.TipoPropiedadId != tipoPropiedad.TipoPropiedadId);
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

        public void Guardar(TipoPropiedad tipoPropiedad)
        {
            try
            {
                if (tipoPropiedad.TipoPropiedadId == 0)
                {
                    _context.TiposPropiedades.Add(tipoPropiedad);
                }
                else 
                {
                    var tipoProInDb = _context.TiposPropiedades
                        .SingleOrDefault(tp => tp.TipoPropiedadId == tipoPropiedad.TipoPropiedadId);
                    tipoProInDb.DescripcionTP = tipoPropiedad.DescripcionTP;
                    _context.Entry(tipoProInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Error al agregar/editar un Tipo de Propiedad");
            }
        }
    }


}
