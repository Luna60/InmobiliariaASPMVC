using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositorioClientes : IRepositorioCliente
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositorioClientes(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }
        public List<ClienteListDto> GetLista()
        {
            try
            {
                var listaDto = _context.Clientes
                    .Include(c => c.Provincia)
                    .Include(c => c.Localidad)
                    .Select(l => new ClienteListDto
                    {
                        ClienteId = l.ClienteId,
                        Apellido = l.Apellido,
                        Provincia = l.Provincia.NombreProvincia,
                        Localidad = l.Localidad.NombreLocalidad
                    }).ToList();
                return listaDto;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Clientes");
            }
        }

    }
}
