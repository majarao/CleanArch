using CleanArch.Domain.Entities;

namespace CleanArch.Application.Abstractions;

public interface IIngredientService
{
    IQueryable<Ingredient>? Get();
    Ingredient? GetById(Guid ingredientId);
    Ingredient Create(Ingredient ingredient);
    Ingredient Update(Ingredient ingredient);
    bool Remove(Guid ingredientId);
}
