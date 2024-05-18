namespace CleanArch.Domain.Entities;

public class Menu
{
    public Guid MenuId { get; set; }
    public string MenuTitle { get; set; } = string.Empty;
    public ICollection<Dish>? Dishes { get; set; }
}
