using CleanArch.Application.Abstractions;
using CleanArch.Application.Services;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[Route("[controller]")]
[ApiController]
public class IngredientsController(IIngredientService ingredientService) : ControllerBase
{
    private readonly IIngredientService ingredientService = ingredientService;

    [HttpPost]
    public ActionResult<Ingredient> Create(Ingredient ingredient)
    {
        ingredient = ingredientService.Create(ingredient);
        return Ok(ingredient);
    }

    [HttpDelete("ingredientId:guid")]
    public ActionResult Remove(Guid ingredientId)
    {
        Ingredient? ingredient = ingredientService.GetById(ingredientId);
        if (ingredient is null)
            return NoContent();

        if (!ingredientService.Remove(ingredientId))
            return BadRequest();

        return Ok();
    }

    [HttpGet]
    public ActionResult<IQueryable<Ingredient>> Get()
    {
        IQueryable<Ingredient>? ingredients = ingredientService.Get();
        if (ingredients!.Any())
            return Ok(ingredients);

        return NoContent();
    }

    [HttpGet("ingredientId:guid")]
    public ActionResult<Ingredient> ReadById(Guid ingredientId)
    {
        Ingredient? ingredient = ingredientService.GetById(ingredientId);
        if (ingredient is null)
            return NoContent();

        return Ok(ingredient);
    }

    [HttpPut("ingredientId:guid")]
    public ActionResult<bool> Update(Guid ingredientId, Ingredient ingredient)
    {
        if (ingredient is null)
            return NoContent();

        if (ingredientId != ingredient.IngredientId)
            return BadRequest();

        ingredient = ingredientService.Update(ingredient);
        return Ok(ingredient);
    }
}
