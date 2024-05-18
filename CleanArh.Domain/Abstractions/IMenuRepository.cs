using CleanArch.Domain.Entities;

namespace CleanArch.Domain.Abstractions;

public interface IMenuRepository
{
    IQueryable<Menu>? Get();
    Menu? GetById(Guid menuId);
    Menu Create(Menu menu);
    Menu Update(Menu menu);
    bool Remove(Guid menuId);
}
