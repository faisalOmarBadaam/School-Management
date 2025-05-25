using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using SchoolProject.Core.Behaviors;
using System.Reflection;

namespace SchoolProject.Core.Dependency_injection
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCoreServices(this IServiceCollection Services)
        {
            return Services.AddExitingLibrary()
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(BehaviorValidation<,>));

        }
        private static IServiceCollection AddExitingLibrary(this IServiceCollection Services)
        {
            return Services.AddMediatR(x => x.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()))
                           .AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

        }
    }
}
