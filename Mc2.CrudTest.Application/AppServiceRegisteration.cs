using Microsoft.Extensions.DependencyInjection;
using MediatR;
using System.Reflection;

namespace Mc2.CrudTest.Application
{
    public static class AppServiceRegisteration
    {
        public static IServiceCollection ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
