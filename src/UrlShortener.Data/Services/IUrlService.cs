using UrlShortener.Data.Models;

namespace UrlShortener.Data.Services;

public interface IUrlService
{
    Task<Url?> GetUrl(string shortUrl);

    Task<IList<Url>> GetUrls();

    Task<string> CreateUrl(string longUrl, string localAddress);
}