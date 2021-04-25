using AutoMapper;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Entidades.DTOs.Cliente;
using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

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

        public void Borrar(int ClienteId)
        {
            try
            {
                var clienteInDb = _context.Clientes.SingleOrDefault(p => p.ClienteId == ClienteId);
                if (clienteInDb == null)
                {
                    throw new Exception("Cliente inexistente :/ ");

                }

                _context.Entry(clienteInDb).State = EntityState.Deleted;
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar borrar el Cliente");
            }
        }

        public bool Existe(Cliente cliente)
        {
            if (cliente.ClienteId == 0)
            {
                return _context.Clientes.Any(c => c.NroDocumento == cliente.NroDocumento);
            }

            return _context.Clientes.Any(c =>
                c.NroDocumento == cliente.NroDocumento && c.ClienteId != cliente.ClienteId);
        }

        public ClienteEditDto GetClientePorId(int? id)
        {
            try
            {
                return _mapper
                    .Map<ClienteEditDto>(_context.Clientes
                        .SingleOrDefault(c => c.ClienteId == id));
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar leer los Clientes");
            }
        }

        public List<ClienteListDto> GetLista()
        {
            try
            {
                var lista = _context.Clientes
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
                return lista;
            }

            catch (Exception )
            {
                throw new Exception("Error al intentar leer los Clientes");
            }

            //try
            //{
            //    if (provincia == null)
            //    {
            //        var lista = _context.Clientes
            //            .Include(c => c.Provincia)
            //    .Select(c => new ClienteListDto
            //    {
            //        ClienteId = c.ClienteId,
            //        NombreLocalidad = p.NombreLocalidad,
            //        Provincia = p.Provincia.NombreProvincia,
            //    }).ToList();
            //        return lista;

            //    }
            //    else
            //    {
            //        var lista = _context.Localidades.Include(p => p.Provincia)
            //            .Where(p => p.Provincia.NombreProvincia == provincia)
            //            .Select(p => new LocalidadListDto
            //            {
            //                LocalidadId = p.LocalidadId,
            //                NombreLocalidad = p.NombreLocalidad,
            //                Provincia = p.Provincia.NombreProvincia,
            //            }).ToList();
            //        return lista;

            //    }
            //}
            //catch (Exception e)
            //{

            //    throw new Exception("Error al intentar leer las Localidades");
            //}
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
                        .SingleOrDefault(c => c.ClienteId == cliente.ClienteId);
                    clienteInDb.Nombre = cliente.Nombre;
                    clienteInDb.Apellido = cliente.Apellido;
                    clienteInDb.TipoDocumentoId = cliente.TipoDocumentoId;
                    clienteInDb.NroDocumento = cliente.NroDocumento;
                    clienteInDb.Direccion = cliente.Direccion;

                    clienteInDb.ProvinciaId = cliente.ProvinciaId;
                    clienteInDb.LocalidadId = cliente.LocalidadId;
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
