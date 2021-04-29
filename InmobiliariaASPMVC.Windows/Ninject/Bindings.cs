using InmobiliariaASPMVC.Datos;
using InmobiliariaASPMVC.Datos.Repositorios;
using InmobiliariaASPMVC.Datos.Repositorios.Facades;
using InmobiliariaASPMVC.Servicios.Servicios;
using InmobiliariaASPMVC.Servicios.Servicios.Facades;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InmobiliariaASPMVC.Windows.Ninject
{
    public class Bindings : NinjectModule
    {
        public override void Load()
        {
            Bind<InmobiliariaDbContext>().ToSelf().InSingletonScope();
            Bind<IUnitOfWork>().To<UnitOfWork>();

            Bind<IRepositoriosProvincias>().To<RepositoriosProvincias>();
            Bind<IServiciosProvincias>().To<ServiciosProvincias>();

            Bind<IRepositoriosLocalidades>().To<RepositoriosLocalidades>();
            Bind<IServicioLocalidades>().To<ServiciosLocalidades>();

            Bind<IRepositoriosTiposDocumentos>().To<RepositoriosTiposDocumentos>();
            Bind<IServiciosTiposDocumentos>().To<ServiciosTiposDocumentos>();

            Bind<IRepositoriosClientes>().To<RepositoriosClientes>();
            Bind<IServiciosClientes>().To<ServiciosClientes>();

            Bind<IRepositoriosPropiedades>().To<RepositorioPropiedad>();
            Bind<IServiciosPropiedades>().To<ServiciosPropiedades>();

            Bind<IRepositoriosTiposOperaciones>().To<RepositoriosTiposOperaciones>();
            Bind<IServiciosTiposOperaciones>().To<ServiciosTiposOperaciones>();

            Bind<IRepositoriosTiposPropiedades>().To<RepositoriosTiposPropiedades>();
            Bind<IServiciosTiposPropiedades>().To<ServiciosTiposPropiedades>();

            Bind<IRepositoriosVentas>().To<RepositoriosVentas>();
            Bind<IRepositoriosItemVentas>().To<RepositoriosItemVentas>();
            Bind<IServiciosVentas>().To<ServiciosVentas>();


        }
    }
}
