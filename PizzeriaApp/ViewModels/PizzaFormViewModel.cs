namespace PizzeriaApp.ViewModels;

using System.ComponentModel.DataAnnotations;
using PizzeriaApp.Models;

public class PizzaFormViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "Nazwa jest wymagana")]
    [StringLength(100, ErrorMessage = "Nazwa może mieć maksymalnie 100 znaków")]
    [Display(Name = "Nazwa")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Cena (mała) jest wymagana")]
    [Range(0.01, 10000, ErrorMessage = "Cena musi być większa od 0")]
    [Display(Name = "Cena (mała) [zł]")]
    public decimal? PriceSmall { get; set; }

    [Required(ErrorMessage = "Cena (średnia) jest wymagana")]
    [Range(0.01, 10000, ErrorMessage = "Cena musi być większa od 0")]
    [Display(Name = "Cena (średnia) [zł]")]
    public decimal? PriceMedium { get; set; }

    [Required(ErrorMessage = "Cena (duża) jest wymagana")]
    [Range(0.01, 10000, ErrorMessage = "Cena musi być większa od 0")]
    [Display(Name = "Cena (duża) [zł]")]
    public decimal? PriceLarge { get; set; }

    [Required(ErrorMessage = "Rodzaj ciasta jest wymagany")]
    [Display(Name = "Rodzaj ciasta")]
    public CrustType? CrustType { get; set; }

    public List<int> SelectedIngredientIds { get; set; } = new();

    public List<Ingredient> AvailableIngredients { get; set; } = new();
}
