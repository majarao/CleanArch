using CleanArch.Domain.Entities;

namespace CleanArch.Application.Abstractions;

public interface IMenuService
{
    IQueryable<Menu>? Get();
    Menu? GetById(Guid menuId);
    Menu Create(Menu menu);
    Menu Update(Menu menu);
    bool Remove(Guid menuId);
}
