namespace PlayTime.IoC.Modules
{
    using Autofac;

    using PlayTime.Infrastructure.Interfaces.Repository;
    using PlayTime.Infrastructure.Repository;

    public class RepositoriesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CustomerEntityRepository>().As<ICustomerRepository>();
            builder.RegisterType<UserEntityRepository>().As<IUserRepository>();
            builder.RegisterType<ProjectEntityRepository>().As<IProjectRepository>();
            builder.RegisterType<RegistrationEntityRepository>().As<IRegistrationRepository>();
            builder.RegisterType<TaskEntityRepository>().As<ITaskRepository>();
            builder.RegisterType<InvoiceEntityRepository>().As<IInvoiceRepository>();
        }
    }
}