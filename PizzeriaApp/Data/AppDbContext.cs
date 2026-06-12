namespace PizzeriaApp.Data;

using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Models;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Pizza> Pizzas { get; set; }
    public DbSet<Ingredient> Ingredients { get; set; }
    public DbSet<PizzaIngredient> PizzaIngredients { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PizzaIngredient>()
            .HasKey(pi => new { pi.PizzaId, pi.IngredientId });

        modelBuilder.Entity<PizzaIngredient>()
            .HasOne(pi => pi.Pizza)
            .WithMany(p => p.PizzaIngredients)
            .HasForeignKey(pi => pi.PizzaId);

        modelBuilder.Entity<PizzaIngredient>()
            .HasOne(pi => pi.Ingredient)
            .WithMany(i => i.PizzaIngredients)
            .HasForeignKey(pi => pi.IngredientId);
    }
}
