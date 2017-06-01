using System;
using System.Diagnostics;
using System.Web.Http;
using InvolvedTodo.DAL;
using InvolvedTodo.DAL.Repos.Interfaces;
using Ninject;
using Ninject.Web.Common;


namespace InvolvedTodo
{
    // lifecycle klasse dat bepaalde zaken uitvoert tijdens de lifecycle fasen van de applicatie
    public class Global : NinjectHttpApplication
    {
        protected override void OnApplicationStarted()
        {
            base.OnApplicationStarted();
            GlobalConfiguration.Configure(WebApiConfig.Register);
        }

        private void RegisterServices(IKernel kernel)
        {
            kernel.Bind<IUnitOfWork>().To<UnitOfWork>();
        }
        protected override IKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            RegisterServices(kernel);
            return kernel;
        }
    }
}