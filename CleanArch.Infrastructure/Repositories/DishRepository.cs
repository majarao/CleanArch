using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.Context;

namespace CleanArch.Infrastructure.Repositories;

public class DishRepository(AppDbContext appDbContext) : IDishRepository
{
    private readonly AppDbContext AppDbContext = appDbContext;

    public Dish Create(Dish dish)
    {
        AppDbContext.Set<Dish>().Add(dish);
        AppDbContext.SaveChanges();
        return dish;
    }

    public IQueryable<Dish>? Get() => AppDbContext.Set<Dish>();

    public Dish? GetById(Guid dishId) => Get()?.FirstOrDefault(s => s.DishId == dishId);

    public bool Remove(Guid dishId)
    {
        Dish? dish = GetById(dishId);
        if (dish is not null)
        {
            AppDbContext.Set<Dish>().Remove(dish);
            AppDbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public Dish Update(Dish dish)
    {
        AppDbContext.Set<Dish>().Update(dish);
        AppDbContext.SaveChanges();
        return dish;
    }
}
