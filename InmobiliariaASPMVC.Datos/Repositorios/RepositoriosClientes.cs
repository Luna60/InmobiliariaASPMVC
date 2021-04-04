using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos.Repositorios
{
    public class RepositoriosClientes : IRepositoriosClientes
    {
        private readonly InmobiliariaDbContext _context;
        private readonly IMapper _mapper;

        public RepositoriosClientes(InmobiliariaDbContext context)
        {
            _context = context;
            _mapper = Mapeador.Mapeador.CrearMapper();

        }

        public bool Existe(Cliente cliente)
        {
            if (cliente.ClienteId == 0)
            {
                return _context.Clientes.Any(p => p.NroDocumento == cliente.NroDocumento);
            }

            return _context.Clientes.Any(p =>
                p.NroDocumento == cliente.NroDocumento && p.ClienteId != cliente.ClienteId);
        }

        public List<ClienteListDto> GetLista()
        {
            try
            {
                var listaDto = _context.Clientes
                    .Include(c => c.Provincia)
                    .Include(c => c.Localidad)
                    .Select(c => new ClienteListDto
                    {
                        ClienteId = c.ClienteId,
                        Apellido = c.Apellido,
                        NroDocumento = c.NroDocumento,
                        Provincia = c.Provincia.NombreProvincia,
                        Localidad = c.Localidad.NombreLocalidad,
                        TelefonoMovil = c.TelefonoMovil
                    }).ToList();
                return listaDto;
            }
            catch (Exception)
            {

                throw new Exception("Error al intentar leer los Clientes");
            }
        }

        public void Guardar(Cliente cliente)
        {
            try
            {
                if (cliente.ClienteId == 0)
                {
                    _context.Clientes.Add(cliente);
                }
                else
                {
                    var clienteInDb = _context
                        .Clientes
                        .SingleOrDefault(p => p.ClienteId == cliente.ClienteId);
                    clienteInDb.Nombre = cliente.Nombre;
                    clienteInDb.Apellido = cliente.Apellido;

                    clienteInDb.TipoDocumentoId = cliente.TipoDocumentoId;
                    clienteInDb.NroDocumento = cliente.NroDocumento;
                    clienteInDb.Direccion = cliente.Direccion;
                    clienteInDb.LocalidadId = cliente.LocalidadId;
                    clienteInDb.ProvinciaId = cliente.ProvinciaId;

                    clienteInDb.TelefonoFijo = cliente.TelefonoFijo;
                    clienteInDb.TelefonoMovil = cliente.TelefonoMovil;
                    clienteInDb.CorreoElectronico = cliente.CorreoElectronico;

                    _context.Entry(clienteInDb).State = EntityState.Modified;
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar guardar el Cliente");
            }
        }
    }
}
