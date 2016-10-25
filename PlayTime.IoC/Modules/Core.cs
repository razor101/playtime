namespace PlayTime.IoC.Modules
{
    using Autofac;

    using PlayTime.Data;
    using PlayTime.Security;

    public class Core : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<PlayTimeContext>().InstancePerRequest();
            builder.RegisterType<ActiveDirectory>().InstancePerRequest();
        }
    }
}