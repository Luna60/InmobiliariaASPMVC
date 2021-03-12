using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Provincia;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositorioProvincias : IRepositorioProvincias
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioProvincias(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        //public RepositorioProvincias()
        //{
        //    _context = new InmobiliariaDbContext();
        //    _mapper = Mapeador.Mapeador.CrearMapper();
        //}

        public List<ProvinciaListDto> GetLista()
        {
            try
            {
                var lista = _context.Provincias.ToList();
                return _mapper.Map<List<ProvinciaListDto>>(lista);
            }
            catch (Exception)
            {

                throw new Exception("Error al querer traer las Provincias");
            }
        }

        public ProvinciaEditDto GetProvinciaPorId(int? id)
        {
            try
            {
                //El SingleOrDefault me esta devolviendo una Provincia, yo lo debo pasar a ProvinciaEditDto, 
                //Me fijo si en el MappingProfile, esta CreateMap<Provincia, ProvinciaEditDto>().ReverseMap();, de
                //estar entonces, vuelvo y... le digo que me pase de Provincia a ProvinciaEditDto, basandose en 
                //lo que le pasan en _context.Provincias.SingleOrDefault(p => p.ProvinciaId == id).

                return _mapper
                    .Map<ProvinciaEditDto>(_context.Provincias.SingleOrDefault(p => p.ProvinciaId == id));
            }
            catch (Exception)
            {

                throw new Exception("Error al querer traer la Provincia");
            }
        }

        public void Guardar(Provincia provincia)//para saber la diferencia entre si un dato es nuevo o editado
                                                //se debe mirar en el id que tiene, ya que si ese id, nunca estuvo en la lista, significa que ese dato es nuevo,
                                                //de lo contrario es editado
        {
            try
            {
                if (provincia.ProvinciaId == 0)//si entra es porque se esta creando 
                {
                    _context.Provincias.Add(provincia);
                }
                else
                {
                    var provinciaInDb = _context.Provincias.SingleOrDefault(p => p.ProvinciaId == provincia.ProvinciaId);
                    provinciaInDb.NombreProvincia = provincia.NombreProvincia;
                    _context.Entry(provinciaInDb).State = EntityState.Modified;
                }
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al querer Agregar/Editar la Provincia");
            }
        }


        public void Borrar(int? id)
        {
            try
            {
                var provinciaInDb = _context.Provincias
                    .SingleOrDefault(p => p.ProvinciaId==id);
                _context.Entry(provinciaInDb).State = EntityState.Deleted;
                //_context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al querer Borrar la Provincia");
            }
        }

        public bool Existe(Provincia provincia)
        {

                if (provincia.ProvinciaId == 0)
                {
                    return _context.Provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia);
                }
                return _context.Provincias.Any(p => p.NombreProvincia == provincia.NombreProvincia && 
                p.ProvinciaId!=provincia.ProvinciaId);

        }


    }
}
