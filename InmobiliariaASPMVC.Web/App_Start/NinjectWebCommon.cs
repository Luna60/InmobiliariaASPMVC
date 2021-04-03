using InmobiliariaASPMVC.Web;
    using System;
    using System.Web;
    using InmobiliariaASPMVC.Datos;
    using InmobiliariaASPMVC.Datos.Repositorios;
    using InmobiliariaASPMVC.Datos.Repositorios.Facades;
    using InmobiliariaASPMVC.Servicios.Servicios;
    using InmobiliariaASPMVC.Servicios.Servicios.Facades;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Ninject;
    using Ninject.Web.Common;
    using Ninject.Web.Common.WebHost;

[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(NinjectWebCommon), "Stop")]

namespace InmobiliariaASPMVC.Web
{

    public static class NinjectWebCommon 
    {
        private static readonly Bootstrapper bootstrapper = new Bootstrapper();

        /// <summary>
        /// Starts the application.
        /// </summary>
        public static void Start() 
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        /// <summary>
        /// Stops the application.
        /// </summary>
        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        /// <summary>
        /// Creates the kernel that will manage your application.
        /// </summary>
        /// <returns>The created kernel.</returns>
        private static IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            try
            {
                kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
                kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();
                RegisterServices(kernel);
                return kernel;
            }
            catch
            {
                kernel.Dispose();
                throw;
            }
        }

        /// <summary>
        /// Load your modules or register your services here!
        /// </summary>
        /// <param name="kernel">The kernel.</param>
        private static void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IServiciosProvincias>().To<ServiciosProvincias>().InRequestScope();
            kernel.Bind<IRepositoriosProvincias>().To<RepositoriosProvincias>().InRequestScope();

            kernel.Bind<IServicioLocalidades>().To<ServiciosLocalidades>().InRequestScope();
            kernel.Bind<IRepositoriosLocalidades>().To<RepositoriosLocalidades>().InRequestScope();

            kernel.Bind<IServiciosPropiedades>().To<ServiciosPropiedades>().InRequestScope();
            kernel.Bind<IRepositoriosPropiedades>().To<RepositoriosPropiedades>().InRequestScope();

            kernel.Bind<IServiciosClientes>().To<ServiciosClientes>().InRequestScope();
            kernel.Bind<IRepositoriosClientes>().To<RepositoriosClientes>().InRequestScope();

            kernel.Bind<IUnitOfWork>().To<UnitOfWork>().InRequestScope();
            kernel.Bind(typeof(InmobiliariaDbContext)).ToSelf().InSingletonScope();

        }
    }
}