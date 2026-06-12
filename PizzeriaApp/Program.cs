using Microsoft.EntityFrameworkCore;
using PizzeriaApp.Data;
using PizzeriaApp.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
    db.Database.EnsureCreated();

    if (!db.Ingredients.Any())
    {
        var ingredients = new List<Ingredient>
        {
            new() { Name = "Pepperoni" },
            new() { Name = "Pieczarki" },
            new() { Name = "Oliwki" },
            new() { Name = "Papryka" },
            new() { Name = "Szynka" },
            new() { Name = "Cebula" },
            new() { Name = "Kurczak" },
            new() { Name = "Ananas" }
        };
        db.Ingredients.AddRange(ingredients);
        db.SaveChanges();
    }
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pizza}/{action=Index}/{id?}");

app.Run();
