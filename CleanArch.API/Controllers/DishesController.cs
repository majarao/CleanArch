using CleanArch.Application.Abstractions;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[Route("[controller]")]
[ApiController]
public class DishesController(IDishService dishService) : ControllerBase
{
    private readonly IDishService dishService = dishService;

    [HttpPost]
    public ActionResult<Dish> Create(Dish dish)
    {
        dish = dishService.Create(dish);
        return Ok(dish);
    }

    [HttpDelete("dishId:guid")]
    public ActionResult Remove(Guid dishId)
    {
        Dish? dish = dishService.GetById(dishId);
        if (dish is null)
            return NoContent();

        if (!dishService.Remove(dishId))
            return BadRequest();

        return Ok();
    }

    [HttpGet]
    public ActionResult<IQueryable<Dish>> Get()
    {
        IQueryable<Dish>? dishes = dishService.Get();
        if (dishes!.Any())
            return Ok(dishes);

        return NoContent();
    }

    [HttpGet("dishId:guid")]
    public ActionResult<Dish> ReadById(Guid dishId)
    {
        Dish? dish = dishService.GetById(dishId);
        if (dish is null)
            return NoContent();

        return Ok(dish);
    }

    [HttpPut("dishId:guid")]
    public ActionResult<bool> Update(Guid dishId, Dish dish)
    {
        if (dish is null)
            return NoContent();

        if (dishId != dish.DishId)
            return BadRequest();

        dish = dishService.Update(dish);
        return Ok(dish);
    }
}
