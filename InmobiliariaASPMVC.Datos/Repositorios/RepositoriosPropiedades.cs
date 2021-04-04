using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Propiedad;
using InmobiliariaASPMVC.Entidades.Entidades;
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

        public bool Existe(Propiedad propiedad)
        {
            if (propiedad.PropiedadId == 0)
            {
                return _context.Propiedades.Any(p => p.DescripcionP == propiedad.DescripcionP);
            }

            return _context.Propiedades.Any(p =>
                p.DescripcionP == propiedad.DescripcionP && p.PropiedadId != propiedad.PropiedadId);
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
                        .SingleOrDefault(p => p.ProvinciaId == propiedad.PropiedadId);
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
                    propiedadInDb.CostoOperacion = propiedad.CostoOperacion;
                    propiedadInDb.Observacion = propiedad.Observacion;
                    propiedadInDb.Imagen = propiedad.Imagen;

                    _context.Entry(propiedadInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar la Propiedad");
            }
        }

    }
}
