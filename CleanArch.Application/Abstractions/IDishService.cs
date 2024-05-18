using CleanArch.Domain.Entities;

namespace CleanArch.Application.Abstractions;

public interface IDishService
{
    IQueryable<Dish>? Get();
    Dish? GetById(Guid dishId);
    Dish Create(Dish dish);
    Dish Update(Dish dish);
    bool Remove(Guid dishId);
}
