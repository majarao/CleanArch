using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstractions;

public interface IIngredientRepository
{
    IQueryable<Ingredient>? Get();
    Ingredient? GetById(Guid ingredientId);
    Ingredient Create(Ingredient ingredient);
    Ingredient Update(Ingredient ingredient);
    bool Remove(Guid ingredientId);
}
