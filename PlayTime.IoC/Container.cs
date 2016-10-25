namespace PlayTime.IoC
{
    using System;
    using System.Web.Mvc;

    using Autofac;
    using Autofac.Integration.Mvc;
    
    using IContainer = Autofac.IContainer;

    public class Container
    {
        public static void Build(Type typeOfApplication)
        {
            ContainerBuilder builder = new ContainerBuilder();
            builder.RegisterControllers(typeOfApplication.Assembly);
            
            builder.RegisterModule<Modules.Core>();
            builder.RegisterModule<Modules.RepositoriesModule>();
            builder.RegisterModule<Modules.DomainServicesModule>();
            builder.RegisterModule<Modules.ApplicationServicesModule>();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}