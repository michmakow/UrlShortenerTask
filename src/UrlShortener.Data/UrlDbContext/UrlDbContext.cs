using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Models;

namespace UrlShortener.Data.UrlDbContext;

public class UrlDbContext : DbContext
{
    public DbSet<Url> Urls { get; set; }

    public UrlDbContext(DbContextOptions options) : base(options)
    {
    }
}