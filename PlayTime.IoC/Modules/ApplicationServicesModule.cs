namespace PlayTime.IoC.Modules
{
    using Autofac;

    using PlayTime.Infrastructure.ApplicationServices;
    using PlayTime.Infrastructure.Interfaces.ApplicationServices;

    public class ApplicationServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerApplicationService>().As<ICustomerApplicationService>();
            builder.RegisterType<UserApplicationService>().As<IUserApplicationService>();
            builder.RegisterType<ProjectApplicationService>().As<IProjectApplicationService>();
            builder.RegisterType<RegistrationApplicationService>().As<IRegistrationApplicationService>();
            builder.RegisterType<TaskApplicationService>().As<ITaskApplicationService>();
            builder.RegisterType<InvoiceApplicationService>().As<IInvoiceApplicationService>();
        }
    }
}