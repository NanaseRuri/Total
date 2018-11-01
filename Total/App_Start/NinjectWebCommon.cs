
[assembly: WebActivatorEx.PreApplicationStartMethod(typeof(Total.App_Start.NinjectWebCommon), "Start")]
[assembly: WebActivatorEx.ApplicationShutdownMethodAttribute(typeof(Total.App_Start.NinjectWebCommon), "Stop")]

namespace Total.App_Start
{
    using System;
    using System.Web;
    using System.Web.Mvc;
    using Ninject.Web.Common.WebHost;
    using Microsoft.Web.Infrastructure.DynamicModuleHelper;
    using Total.Infrastructure;

    using Ninject;
    using Ninject.Web.Common;
    public static class NinjectWebCommon
    {
        private static readonly Bootstrapper bootstrapper=new Bootstrapper();

        public static void Start()
        {
            DynamicModuleUtility.RegisterModule(typeof(OnePerRequestHttpModule));
            DynamicModuleUtility.RegisterModule(typeof(NinjectHttpModule));
            bootstrapper.Initialize(CreateKernel);
        }

        public static void Stop()
        {
            bootstrapper.ShutDown();
        }

        private static IKernel CreateKernel()
        {
            var kernel=new StandardKernel();
            kernel.Bind<Func<IKernel>>().ToMethod(ctx => () => new Bootstrapper().Kernel);
            kernel.Bind<IHttpModule>().To<HttpApplicationInitializationHttpModule>();

            RegisterServices(kernel);
            return kernel;
        }

        static void RegisterServices(IKernel kernel)
        {
            DependencyResolver.SetResolver(new NinjectDependencyResolver(kernel));
            DependencyResolver.SetResolver(new CartNinjectDependencyResolver(kernel));
        }
    }
}