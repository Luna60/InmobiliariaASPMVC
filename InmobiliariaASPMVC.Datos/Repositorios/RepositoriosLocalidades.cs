using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Localidad;
//using System.Data.Entity.Core.Objects.DataClasses;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InmobiliariaASPMVC.Entidades.Entidades;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositoriosLocalidades : IRepositoriosLocalidades
    {

        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositoriosLocalidades(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }

        public void Borrar(int provinciaVmLocalidadId)
        {
            try
            {
                var localidadInDb = _context.Localidades.SingleOrDefault(p => p.LocalidadId == provinciaVmLocalidadId);
                if (localidadInDb == null)
                {
                    throw new Exception("Localidad inexistente...");

                }

                _context.Entry(localidadInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar una Localidad");
            }
        }

        public bool Existe(Localidad localidad)
        {
            if (localidad.LocalidadId == 0)
            {
                return _context.Localidades.Any(p => p.NombreLocalidad == localidad.NombreLocalidad);
            }

            return _context.Localidades.Any(p =>
                p.NombreLocalidad == localidad.NombreLocalidad && p.LocalidadId != localidad.LocalidadId);
        }

        public List<LocalidadListDto> GetLista(string provincia)
        {
            try
            {
                if (provincia == null)
                {
                    var lista = _context.Localidades.Include(p => p.Provincia)
                .Select(p => new LocalidadListDto
                {
                    LocalidadId = p.LocalidadId,
                    NombreLocalidad = p.NombreLocalidad,
                    Provincia = p.Provincia.NombreProvincia,
                }).ToList();
                    return lista;

                }
                else
                {
                    var lista = _context.Localidades.Include(p => p.Provincia)
                        .Where(p => p.Provincia.NombreProvincia == provincia)
                        .Select(p => new LocalidadListDto
                        {
                            LocalidadId = p.LocalidadId,
                            NombreLocalidad = p.NombreLocalidad,
                            Provincia = p.Provincia.NombreProvincia,
                        }).ToList();
                    return lista;

                }
            }
            catch (Exception e)
            {

                throw new Exception("Error al intentar leer las Localidades");
            }
        }

        //public List<LocalidadListDto> GetLista()
        //{
        //    try
        //    {
        //        var lista = _context.Localidades.Include(p => p.Provincia)
        //            .Select(p => new LocalidadListDto
        //            {
        //                LocalidadId = p.LocalidadId,
        //                NombreLocalidad = p.NombreLocalidad,
        //                Provincia = p.Provincia.NombreProvincia,
        //            }).ToList();
        //        return lista;
        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception("Error al intentar leer las Localidades");
        //    }
        //}
        public LocalidadEditDto GetLocalidadPorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<LocalidadEditDto>(_context.Localidades
                        .SingleOrDefault(p => p.LocalidadId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer la Localidad");
            }
        }

        public void Guardar(Localidad localidad)
        {
            try
            {
                if (localidad.LocalidadId == 0)
                {
                    _context.Localidades.Add(localidad);
                }
                else
                {
                    var localidadInDb = _context
                        .Localidades
                        .SingleOrDefault(p => p.LocalidadId == localidad.LocalidadId);
                    localidadInDb.NombreLocalidad = localidad.NombreLocalidad;
                    localidadInDb.ProvinciaId = localidad.ProvinciaId;
                    localidadInDb.LocalidadId = localidad.LocalidadId;
                    _context.Entry(localidadInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar la Localidad");
            }
        }
    }
}
