using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositorioPropiedad : IRepositoriosPropiedades
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioPropiedad(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }

        public void Borrar(int PropiedadId)
        {
            try
            {
                var propiedadInDb = _context.Propiedades.SingleOrDefault(p => p.PropiedadId == PropiedadId);
                if (propiedadInDb == null)
                {
                    throw new Exception("Propiedad inexistente :/ ");

                }

                _context.Entry(propiedadInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar la Propiedad");
            }
        }

        public bool Existe(Propiedad propiedad)
        {
            if (propiedad.PropiedadId == 0)
            {
                return _context.Propiedades.Any(c => c.Direccion == propiedad.Direccion
                && c.Disponible == propiedad.Disponible /*&& c.FechaIngreso == propiedad.FechaIngreso*/
                 && c.LocalidadId== propiedad.LocalidadId);
            }

            return _context.Propiedades.Any(
                c => c.Direccion == propiedad.Direccion
                && c.Disponible == propiedad.Disponible /*&& c.FechaIngreso == propiedad.FechaIngreso*/
                && c.LocalidadId == propiedad.LocalidadId
                && c.PropiedadId != propiedad.PropiedadId);
        }

        public List<PropiedadListDto> GetLista(string provincia)
        {
            try
            {
                if (provincia == null)
                {
                    var lista = _context.Propiedades
                        .Include(c => c.Provincia)
                        .Include(c => c.Localidad)
                        .Include(c => c.TipoOperacion)
                        .Include(c => c.TipoPropiedad)
                        .Include(c => c.Cliente)

                .Select(c => new PropiedadListDto
                {
                    PropiedadId = c.PropiedadId,

                    Disponible = c.Disponible,
                    CostoOperacion = c.CostoOperacion,
                    TipoPropiedad = c.TipoPropiedad.DescripcionTP,
                    TipoOperacion = c.TipoOperacion.DescripcionTO,
                    Cliente = c.Cliente.Apellido,

                    Provincia = c.Provincia.NombreProvincia,
                    Localidad = c.Localidad.NombreLocalidad,
                }).ToList();
                    return lista;

                }
                else
                {
                    var lista = _context.Propiedades
                        .Include(c => c.Provincia)
                        .Include(c => c.Localidad)
                        .Include(c => c.TipoOperacion)
                        .Include(c => c.TipoPropiedad)
                        .Include(c => c.Cliente)

                        .Where(c => c.Provincia.NombreProvincia == provincia)
                .Select(c => new PropiedadListDto
                {
                    PropiedadId = c.PropiedadId,
                    Disponible = c.Disponible,
                    CostoOperacion = c.CostoOperacion,
                    TipoPropiedad = c.TipoPropiedad.DescripcionTP,
                    TipoOperacion = c.TipoOperacion.DescripcionTO,
                    Cliente = c.Cliente.Apellido,

                    Provincia = c.Provincia.NombreProvincia,
                    Localidad = c.Localidad.NombreLocalidad,
                }).ToList();
                    return lista;

                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al intentar leer las Propiedades");
            }
        }

        public PropiedadEditDto GetPropiedadPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<PropiedadEditDto>(_context.Propiedades
                        .SingleOrDefault(c => c.PropiedadId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer la Propiedad");
            }
        }

        public void Guardar(Propiedad propiedad)
        {
            try
            {
                if (propiedad.PropiedadId == 0)
                {
                    _context.Propiedades.Add(propiedad);
                }
                else
                {
                    var propiedadInDb = _context
                        .Propiedades
                        .SingleOrDefault(c => c.PropiedadId == propiedad.PropiedadId);

                    propiedadInDb.DescripcionP = propiedad.DescripcionP;
                    propiedadInDb.TipoPropiedadId = propiedad.TipoPropiedadId;
                    propiedadInDb.TipoOperacionId = propiedad.TipoOperacionId;
                    propiedadInDb.ClienteId = propiedad.ClienteId;

                    propiedadInDb.FechaIngreso = propiedad.FechaIngreso;
                    propiedadInDb.Disponible = propiedad.Disponible;
                    propiedadInDb.Ambientes = propiedad.Ambientes;
                    propiedadInDb.SuperficieTerreno = propiedad.SuperficieTerreno;
                    propiedadInDb.SuperficieEdificada = propiedad.SuperficieEdificada;

                    propiedadInDb.Direccion = propiedad.Direccion;
                    propiedadInDb.Departamento = propiedad.Departamento;

                    propiedadInDb.Jardin = propiedad.Jardin;
                    propiedadInDb.Garage = propiedad.Garage;
                    propiedadInDb.Cochera = propiedad.Cochera;


                    propiedadInDb.ProvinciaId = propiedad.ProvinciaId;
                    propiedadInDb.LocalidadId = propiedad.LocalidadId;

                    propiedadInDb.Observaciones = propiedad.Observaciones;
                    propiedadInDb.CostoOperacion = propiedad.CostoOperacion;
                    propiedadInDb.Imagen = propiedad.Imagen;


                    _context.Entry(propiedadInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar las Propiedades");
            }
        }
    }
}
