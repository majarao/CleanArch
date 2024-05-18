using CleanArch.Application.Abstractions;
using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Services;

public class IngredientService(IIngredientRepository ingredientRepository) : IIngredientService
{
    private readonly IIngredientRepository ingredientRepository = ingredientRepository;

    public Ingredient Create(Ingredient ingredient) => ingredientRepository.Create(ingredient);

    public IQueryable<Ingredient>? Get() => ingredientRepository.Get();

    public Ingredient? GetById(Guid ingredientId) => ingredientRepository.GetById(ingredientId);

    public bool Remove(Guid ingredientId) => ingredientRepository.Remove(ingredientId);

    public Ingredient Update(Ingredient ingredient) => ingredientRepository.Update(ingredient);
}
