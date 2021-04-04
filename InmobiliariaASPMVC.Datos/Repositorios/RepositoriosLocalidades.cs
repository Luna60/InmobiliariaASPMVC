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

        public bool Existe(Localidad localidad)
        {
            if (localidad.LocalidadId == 0)
            {
                return _context.Localidades.Any(p => p.NombreLocalidad == localidad.NombreLocalidad);
            }

            return _context.Localidades.Any(p =>
                p.NombreLocalidad == localidad.NombreLocalidad && p.LocalidadId != localidad.LocalidadId);
        }

        public List<LocalidadListDto> GetLista()
        {
            try
            {
                var listaDto = _context.Localidades
                    .Include(l => l.Provincia)
                    .Select(l => new LocalidadListDto
                    {
                        LocalidadId = l.LocalidadId,
                        NombreLocalidad = l.NombreLocalidad,
                        Provincia = l.Provincia.NombreProvincia
                    }).ToList();
                return listaDto;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer las Localidades");
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
