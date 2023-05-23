using API.Validations;
using Autofac;

namespace API.Core.DI
{
    public class ValidatorRegister : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof(CalculateCDBQueryValidator).Assembly)
                .Where(a => a.Name.EndsWith("Validator"))
                .AsImplementedInterfaces();

            base.Load(builder);
        }
    }
}
