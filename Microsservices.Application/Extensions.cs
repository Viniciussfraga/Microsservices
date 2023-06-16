using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsservices.Application.Commands;

namespace Microsservices.Application
{
    public static class Extensions
    {
        public static IServiceCollection AddHandlers(this IServiceCollection services)
        {
            services.AddMediatR(typeof(AddOrder));

            return services;
        }
    }
}
