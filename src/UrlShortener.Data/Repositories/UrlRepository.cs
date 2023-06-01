using Microsoft.EntityFrameworkCore;
using UrlShortener.Data.Models;

namespace UrlShortener.Data.Repositories;

public class UrlRepository : IUrlRepository
{
    private readonly UrlDbContext.UrlDbContext _urlDbContext;

    public UrlRepository(UrlDbContext.UrlDbContext urlDbContext)
    {
        _urlDbContext = urlDbContext;
    }

    public async Task<IList<Url>> GetUrls() => await _urlDbContext.Urls.ToListAsync();

    public async Task<Url?> GetUrl(string shortUrl) => await _urlDbContext.Urls.FirstOrDefaultAsync(u => u.ShortUrl.Contains(shortUrl));

    public async Task CreateUrl(Url url)
    {
        await _urlDbContext.AddAsync(url);
        await _urlDbContext.SaveChangesAsync();
    }
}