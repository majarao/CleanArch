namespace CleanArch.Domain.Entities;

public class Dish
{
    public Guid DishId { get; set; }
    public string DishName { get; set; } = string.Empty;
    public ICollection<Ingredient>? Ingredients { get; set; }
}
