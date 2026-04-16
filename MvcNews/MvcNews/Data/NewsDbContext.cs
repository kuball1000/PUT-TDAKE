using Microsoft.EntityFrameworkCore;
using MvcNews.Models;

public class NewsDbContext : DbContext
{
    public NewsDbContext(DbContextOptions<NewsDbContext> options) :
    base(options)
    { }
    public DbSet<NewsItem> News { get; set; } = null!;
}
