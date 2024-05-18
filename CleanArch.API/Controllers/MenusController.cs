using CleanArch.Application.Abstractions;
using CleanArch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArch.API.Controllers;

[Route("[controller]")]
[ApiController]
public class MenusController(IMenuService menuService) : ControllerBase
{
    private readonly IMenuService menuService = menuService;

    [HttpPost]
    public ActionResult<Menu> Create(Menu menu)
    {
        menu = menuService.Create(menu);
        return Ok(menu);
    }

    [HttpDelete("menuId:guid")]
    public ActionResult Remove(Guid menuId)
    {
        Menu? menu = menuService.GetById(menuId);
        if (menu is null)
            return NoContent();

        if (!menuService.Remove(menuId))
            return BadRequest();

        return Ok();
    }

    [HttpGet]
    public ActionResult<IQueryable<Menu>> Get()
    {
        IQueryable<Menu>? menus = menuService.Get();
        if (menus!.Any())
            return Ok(menus);

        return NoContent();
    }

    [HttpGet("menuId:guid")]
    public ActionResult<Menu> ReadById(Guid menuId)
    {
        Menu? menu = menuService.GetById(menuId);
        if (menu is null)
            return NoContent();

        return Ok(menu);
    }

    [HttpPut("menuId:guid")]
    public ActionResult<bool> Update(Guid menuId, Menu menu)
    {
        if (menu is null)
            return NoContent();

        if (menuId != menu.MenuId)
            return BadRequest();

        menu = menuService.Update(menu);
        return Ok(menu);
    }
}

