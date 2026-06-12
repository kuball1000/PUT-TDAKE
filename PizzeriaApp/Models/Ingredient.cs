namespace PizzeriaApp.Models;

using System.ComponentModel.DataAnnotations;

public class Ingredient
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nazwa składnika jest wymagana")]
    [StringLength(100, ErrorMessage = "Nazwa może mieć maksymalnie 100 znaków")]
    [Display(Name = "Nazwa składnika")]
    public string Name { get; set; } = string.Empty;

    public ICollection<PizzaIngredient> PizzaIngredients { get; set; } = new List<PizzaIngredient>();
}
