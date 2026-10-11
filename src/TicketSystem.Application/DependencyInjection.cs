namespace TicketSystem.Application;

using Microsoft.Extensions.DependencyInjection;
using TicketSystem.Application.Features.Categories.Interfaces;
using TicketSystem.Application.Features.Categories.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<ICategoryService, CategoryService>();
        return services;
    }
}