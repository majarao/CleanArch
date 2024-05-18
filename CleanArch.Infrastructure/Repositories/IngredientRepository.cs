using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.Context;

namespace CleanArch.Infrastructure.Repositories;

public class IngredientRepository(AppDbContext appDbContext) : IIngredientRepository
{
    private readonly AppDbContext AppDbContext = appDbContext;

    public Ingredient Create(Ingredient ingredient)
    {
        AppDbContext.Set<Ingredient>().Add(ingredient);
        AppDbContext.SaveChanges();
        return ingredient;
    }

    public IQueryable<Ingredient>? Get() => AppDbContext.Set<Ingredient>();

    public Ingredient? GetById(Guid ingredientId) => Get()?.FirstOrDefault(s => s.IngredientId == ingredientId);

    public bool Remove(Guid ingredientId)
    {
        Ingredient? ingredient = GetById(ingredientId);
        if (ingredient is not null)
        {
            AppDbContext.Set<Ingredient>().Remove(ingredient);
            AppDbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public Ingredient Update(Ingredient ingredient)
    {
        AppDbContext.Set<Ingredient>().Update(ingredient);
        AppDbContext.SaveChanges();
        return ingredient;
    }
}
