using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositoriosTiposDocumentos : IRepositoriosTiposDocumentos
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositoriosTiposDocumentos(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int? id)
        {
            try
            {
                var tipoDocInDb = _context.TiposDocumentos
                    .SingleOrDefault(tp => tp.TipoDocumentoId == id);
                _context.Entry(tipoDocInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception e)
            {
                throw new Exception("Error al borrar un Tipo de Documento");
            }
        }

        public bool Existe(TipoDocumento tipoDocumento)
        {
            if (tipoDocumento.TipoDocumentoId == 0)
            {
                return _context.TiposDocumentos.Any(tp => tp.DescripcionTD == tipoDocumento.DescripcionTD);
            }

            return _context.TiposDocumentos.Any(tp =>
                tp.DescripcionTD == tipoDocumento.DescripcionTD && tp.TipoDocumentoId != tipoDocumento.TipoDocumentoId);
        }

        public List<TipoDocumentoListDto> GetLista()
        {
            try
            {
                var lista = _context.TiposDocumentos.ToList();
                return _mapper.Map<List<TipoDocumentoListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al querer traer los Tipos de Documentos");
            }
        }

        public TipoDocumentoEditDto GetTipoDocumentoPorId(int? id)
        {
            try
            {
                //El SingleOrDefault me esta devolviendo una Provincia, yo lo debo pasar a ProvinciaEditDto, 
                //Me fijo si en el MappingProfile, esta CreateMap<Provincia, ProvinciaEditDto>().ReverseMap();, de
                //estar entonces, vuelvo y... le digo que me pase de Provincia a ProvinciaEditDto, basandose en 
                //lo que le pasan en _context.Provincias.SingleOrDefault(p => p.ProvinciaId == id).

                return _mapper
                    .Map<TipoDocumentoEditDto>(_context.TiposDocumentos.SingleOrDefault(p => p.TipoDocumentoId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al querer traer el Tipo de Documento");
            }
        }

        public void Guardar(TipoDocumento tipoDocumento)
        {
            try
            {
                if (tipoDocumento.TipoDocumentoId == 0)
                {
                    _context.TiposDocumentos.Add(tipoDocumento);
                }
                else
                {
                    var tipoDocInDb = _context.TiposDocumentos
                        .SingleOrDefault(tp => tp.TipoDocumentoId == tipoDocumento.TipoDocumentoId);
                    tipoDocInDb.DescripcionTD = tipoDocumento.DescripcionTD;
                    _context.Entry(tipoDocInDb).State = EntityState.Modified;
                }

                //_context.SaveChanges();

            }
            catch (Exception)
            {

                throw new Exception("Error al agregar/editar un Tipo de Documento");
            }

        }
    }
}
