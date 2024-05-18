using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;
using CleanArch.Infrastructure.Context;
using System;

namespace CleanArch.Infrastructure.Repositories;

public class MenuRepository(AppDbContext appDbContext) : IMenuRepository
{
    private readonly AppDbContext AppDbContext = appDbContext;

    public Menu Create(Menu menu)
    {
        AppDbContext.Set<Menu>().Add(menu);
        AppDbContext.SaveChanges();
        return menu;
    }

    public IQueryable<Menu>? Get() => AppDbContext.Set<Menu>();

    public Menu? GetById(Guid menuId) => Get()?.FirstOrDefault(s => s.MenuId == menuId);

    public bool Remove(Guid menuId)
    {
        Menu? menu = GetById(menuId);
        if (menu is not null)
        {
            AppDbContext.Set<Menu>().Remove(menu);
            AppDbContext.SaveChanges();
            return true;
        }

        return false;
    }

    public Menu Update(Menu menu)
    {
        AppDbContext.Set<Menu>().Update(menu);
        AppDbContext.SaveChanges();
        return menu;
    }
}
