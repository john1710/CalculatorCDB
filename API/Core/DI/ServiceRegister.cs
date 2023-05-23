using API.Services;
using Autofac;

namespace API.Core.DI
{
    public class ServiceRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CalculatorCDBService).Assembly)
                .Where(a => a.Name.EndsWith("Service"))
                .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
