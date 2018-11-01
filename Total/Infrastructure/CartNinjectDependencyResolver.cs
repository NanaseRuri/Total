using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Ninject;
using ShoppingCartDomain.Abstract;
using ShoppingCartDomain.Concrete;

namespace Total.Infrastructure
{
    public class CartNinjectDependencyResolver:IDependencyResolver
    {
        private IKernel kernel;

        public CartNinjectDependencyResolver(IKernel kernel)
        {
            this.kernel = kernel;
            AddBindings();
        }

        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }

        void AddBindings()
        {
            kernel.Bind<IProductRepository>().To<EFProductRepository>();
            EmailSettings emailSettings=new EmailSettings(){WriteAsFile = bool.Parse(ConfigurationManager.AppSettings["Email.WriteAsFile"]??"false")};
            kernel.Bind<IOrderProcessor>().To<MailProcessor>().WithConstructorArgument("settings", emailSettings);
            kernel.Bind<IAuthorProvider>().To<FormsAuthorProvider>();
        }
    }
}