using CleanArch.Application.Abstractions;
using CleanArch.Application.Services;
using CleanArch.Domain.Abstractions;
using CleanArch.Infrastructure.Context;
using CleanArch.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CleanArch.CrossCutting.IoC;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(option => option
            .UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

        services.AddScoped<IDishRepository, DishRepository>();
        services.AddScoped<IIngredientRepository, IngredientRepository>();
        services.AddScoped<IMenuRepository, MenuRepository>();

        services.AddScoped<IDishService, DishService>();
        services.AddScoped<IIngredientService, IngredientService>();
        services.AddScoped<IMenuService, MenuService>();

        return services;
    }
}
