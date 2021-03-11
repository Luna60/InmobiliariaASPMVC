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
        public RepositorioProvincias()
        {
            _context = new InmobiliariaDbContext();
            _mapper = Mapeador.Mapeador.CrearMapper();
        }

        public void Borrar(int? id)
        {
            try
            {
                var provinciaInDb = _context.Provincias.Find(id);
                _context.Entry(provinciaInDb).State = EntityState.Deleted;
                _context.SaveChanges();
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
                p.ProvinciaId==provincia.ProvinciaId);

        }
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

        public Provincia GetProvinciaPorId(int? id)
        {
            try
            {
                return _context.Provincias.SingleOrDefault(p => p.ProvinciaId == id);
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
                if (provincia.ProvinciaId == 0)
                {
                    _context.Provincias.Add(provincia);
                }
                else
                {
                    var provinciaInDb = _context.Provincias.Find(provincia.ProvinciaId);
                    provinciaInDb.NombreProvincia = provincia.NombreProvincia;
                }
                _context.SaveChanges();
            }
            catch (Exception)
            {

                throw new Exception("Error al querer Agregar/Editar la Provincia");
            }
        }
    }
}
