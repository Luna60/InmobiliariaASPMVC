using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.TipoOperacion;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositoriosTiposOperaciones : IRepositoriosTiposOperaciones
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositoriosTiposOperaciones(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int? id)
        {
            try
            {
                var tipoOpeInDb = _context.TiposOperaciones
                    .SingleOrDefault(tp => tp.TipoOperacionId == id);
                _context.Entry(tipoOpeInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error al borrar un Tipo de Operacion");
            }
        }

        public bool Existe(TipoOperacion tipoOperacion)
        {
            if (tipoOperacion.TipoOperacionId == 0)
            {
                return _context.TiposOperaciones.Any(tp => tp.DescripcionTO == tipoOperacion.DescripcionTO);
            }

            return _context.TiposOperaciones.Any(tp =>
                tp.DescripcionTO == tipoOperacion.DescripcionTO && tp.TipoOperacionId != tipoOperacion.TipoOperacionId);
        }

        public List<TipoOperacionListDto> GetLista()
        {
            try
            {
                var lista = _context.TiposOperaciones.ToList();
                return _mapper.Map<List<TipoOperacionListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al querer traer los Tipos de Operaciones");
            }
        }

        public TipoOperacionEditDto GetTipoOperacionPorId(int? id)
        {
            try
            {
                //El SingleOrDefault me esta devolviendo una Provincia, yo lo debo pasar a ProvinciaEditDto, 
                //Me fijo si en el MappingProfile, esta CreateMap<Provincia, ProvinciaEditDto>().ReverseMap();, de
                //estar entonces, vuelvo y... le digo que me pase de Provincia a ProvinciaEditDto, basandose en 
                //lo que le pasan en _context.Provincias.SingleOrDefault(p => p.ProvinciaId == id).

                return _mapper
                    .Map<TipoOperacionEditDto>(_context.TiposOperaciones.SingleOrDefault(p => p.TipoOperacionId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al querer traer el Tipo de Operación");
            }
        }

        public void Guardar(TipoOperacion tipoOperacion)
        {
            try
            {
                if (tipoOperacion.TipoOperacionId == 0)
                {
                    _context.TiposOperaciones.Add(tipoOperacion);
                }
                else 
                {
                    var tipoOpeInDb = _context.TiposOperaciones
                        .SingleOrDefault(tp => tp.TipoOperacionId == tipoOperacion.TipoOperacionId);
                    tipoOpeInDb.DescripcionTO = tipoOperacion.DescripcionTO;
                    _context.Entry(tipoOpeInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Error al agregar/editar un Tipo de Operacion");
            }
        }
    }
}
