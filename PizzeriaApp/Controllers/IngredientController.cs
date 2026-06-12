namespace PizzeriaApp.Controllers;

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Data;
using PizzeriaApp.Models;

public class IngredientController : Controller
{
    private readonly AppDbContext _context;

    public IngredientController(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.Ingredients
            .Include(i => i.PizzaIngredients)
            .OrderBy(i => i.Name)
            .ToListAsync());
    }

    public IActionResult Create()
    {
        return View(new Ingredient());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(Ingredient ingredient)
    {
        if (!ModelState.IsValid) return View(ingredient);

        _context.Ingredients.Add(ingredient);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int id)
    {
        var ingredient = await _context.Ingredients.FindAsync(id);
        if (ingredient == null) return NotFound();
        return View(ingredient);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Ingredient ingredient)
    {
        if (id != ingredient.Id) return BadRequest();
        if (!ModelState.IsValid) return View(ingredient);

        _context.Update(ingredient);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Delete(int id)
    {
        var ingredient = await _context.Ingredients
            .Include(i => i.PizzaIngredients)
            .FirstOrDefaultAsync(i => i.Id == id);

        if (ingredient == null) return NotFound();

        if (ingredient.PizzaIngredients.Any())
        {
            TempData["Error"] = $"Nie można usunąć składnika \"{ingredient.Name}\" - jest używany przez {ingredient.PizzaIngredients.Count} pizzę(pizz).";
            return RedirectToAction(nameof(Index));
        }

        _context.Ingredients.Remove(ingredient);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
}
