namespace PlayTime.IoC.Modules
{
    using Autofac;

    using PlayTime.Infrastructure.DomainServices;
    using PlayTime.Infrastructure.Interfaces.DomainServices;

    public class DomainServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerDomainService>().As<ICustomerDomainService>();
            builder.RegisterType<UserDomainService>().As<IUserDomainService>();
            builder.RegisterType<ProjectDomainService>().As<IProjectDomainService>();
            builder.RegisterType<RegistrationDomainService>().As<IRegistrationDomainService>();
            builder.RegisterType<TaskDomainService>().As<ITaskDomainService>();
            builder.RegisterType<InvoiceDomainService>().As<IInvoiceDomainService>();
        }
    }
}