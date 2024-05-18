using CleanArch.Application.Abstractions;
using CleanArch.Domain.Abstractions;
using CleanArch.Domain.Entities;

namespace CleanArch.Application.Services;

public class MenuService(IMenuRepository menuRepository) : IMenuService
{
    private readonly IMenuRepository menuRepository = menuRepository;

    public Menu Create(Menu menu) => menuRepository.Create(menu);

    public IQueryable<Menu>? Get() => menuRepository.Get();

    public Menu? GetById(Guid menuId) => menuRepository.GetById(menuId);

    public bool Remove(Guid menuId) => menuRepository.Remove(menuId);

    public Menu Update(Menu menu) => menuRepository.Update(menu);
}
