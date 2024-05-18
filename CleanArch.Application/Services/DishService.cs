using CleanArch.Application.Abstractions;
using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Services;

public class DishService(IDishRepository dishRepository) : IDishService
{
    private readonly IDishRepository dishRepository = dishRepository;

    public Dish Create(Dish dish) => dishRepository.Create(dish);

    public IQueryable<Dish>? Get() => dishRepository.Get();

    public Dish? GetById(Guid dishId) => dishRepository.GetById(dishId);

    public bool Remove(Guid dishId) => dishRepository.Remove(dishId);

    public Dish Update(Dish dish) => dishRepository.Update(dish);
}
