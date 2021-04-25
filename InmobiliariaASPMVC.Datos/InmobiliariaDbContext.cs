using InmobiliariaASPMVC.Entidades.Entidades;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Datos
{
    public class InmobiliariaDbContext:DbContext
    {
        public InmobiliariaDbContext():base("MiConexion")
        {
            Database.CommandTimeout = 50;
            Configuration.UseDatabaseNullSemantics = true;

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<InmobiliariaDbContext>(null);//Evito me vuelva a generar la base de datos
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>(); //evita el borrado en cascada
            modelBuilder.Configurations.AddFromAssembly(Assembly.GetExecutingAssembly()); //le digo que tome las configuraciones del  mismo assembly
        }

        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Localidad> Localidades { get; set; }
        //public DbSet<Propiedad> Propiedades { get; set; }
        public DbSet<TipoPropiedad> TiposPropiedades { get; set; }
        public DbSet<TipoOperacion> TiposOperaciones { get; set; }
        public DbSet<TipoDocumento> TiposDocumentos{ get; set; }
        public DbSet<Cliente> Clientes { get; set; }

    }
}
