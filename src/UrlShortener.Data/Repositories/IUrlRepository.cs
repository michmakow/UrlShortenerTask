using UrlShortener.Data.Models;

namespace UrlShortener.Data.Repositories;

public interface IUrlRepository
{
    Task<Url?> GetUrl(string shortUrl);

    Task<IList<Url>> GetUrls();

    Task CreateUrl(Url url);
}