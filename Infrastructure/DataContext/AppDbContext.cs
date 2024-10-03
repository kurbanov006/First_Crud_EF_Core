using Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.DataContext;

public class AppDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
}