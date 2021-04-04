using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.TipoDocumento;
using System;
using System.Collections.Generic;
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
    }
}
