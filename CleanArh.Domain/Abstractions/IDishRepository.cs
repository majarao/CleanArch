using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstractions;

public interface IDishRepository
{
    IQueryable<Dish>? Get();
    Dish? GetById(Guid dishId);
    Dish Create(Dish dish);
    Dish Update(Dish dish);
    bool Remove(Guid dishId);
}
