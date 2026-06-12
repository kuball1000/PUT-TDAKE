namespace PizzeriaApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Data;
using PizzeriaApp.Models;
using PizzeriaApp.ViewModels;

public class PizzaController : Controller
{
    private readonly AppDbContext _context;

    public PizzaController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(string? search)
    {
        ViewBag.Search = search;
        var query = _context.Pizzas
            .Include(p => p.PizzaIngredients)
            .ThenInclude(pi => pi.Ingredient)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(search))
            query = query.Where(p => p.Name.StartsWith(search));

        return View(await query.OrderBy(p => p.Name).ToListAsync());
    }

    public async Task<IActionResult> Details(int id)
    {
        var pizza = await _context.Pizzas
            .Include(p => p.PizzaIngredients)
            .ThenInclude(pi => pi.Ingredient)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pizza == null) return NotFound();
        return View(pizza);
    }

    public async Task<IActionResult> Create()
    {
        return View(new PizzaFormViewModel
        {
            AvailableIngredients = await _context.Ingredients.OrderBy(i => i.Name).ToListAsync()
        });
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(PizzaFormViewModel vm)
    {
        if (!ModelState.IsValid)
        {
            vm.AvailableIngredients = await _context.Ingredients.OrderBy(i => i.Name).ToListAsync();
            return View(vm);
        }

        var pizza = new Pizza
        {
            Name = vm.Name,
            PriceSmall = vm.PriceSmall!.Value,
            PriceMedium = vm.PriceMedium!.Value,
            PriceLarge = vm.PriceLarge!.Value,
            CrustType = vm.CrustType!.Value
        };

        _context.Pizzas.Add(pizza);
        await _context.SaveChangesAsync();

        foreach (var ingredientId in vm.SelectedIngredientIds)
            _context.PizzaIngredients.Add(new PizzaIngredient { PizzaId = pizza.Id, IngredientId = ingredientId });

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int id)
    {
        var pizza = await _context.Pizzas
            .Include(p => p.PizzaIngredients)
            .ThenInclude(pi => pi.Ingredient)
            .FirstOrDefaultAsync(p => p.Id == id);

        if (pizza == null) return NotFound();
        return View(pizza);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var pizza = await _context.Pizzas.FindAsync(id);
        if (pizza != null)
        {
            _context.PizzaIngredients.RemoveRange(
                _context.PizzaIngredients.Where(pi => pi.PizzaId == id));
            _context.Pizzas.Remove(pizza);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
