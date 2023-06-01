using Microsoft.AspNetCore.WebUtilities;
using System.Text;
using UrlShortener.Data.Models;
using UrlShortener.Data.Repositories;

namespace UrlShortener.Data.Services;

public class UrlService : IUrlService
{
    private readonly IUrlRepository _urlRepository;
    private readonly StringBuilder _stringBuilder = new();

    public UrlService(IUrlRepository urlRepository)
    {
        _urlRepository = urlRepository;
    }

    public async Task<IList<Url>> GetUrls() => await _urlRepository.GetUrls();

    public async Task<Url?> GetUrl(string shortUrl) => await _urlRepository.GetUrl(shortUrl);

    public async Task<string> CreateUrl(string longUrl, string localAddress)
    {
        _stringBuilder.Clear();
        var id = Guid.NewGuid();
        var shortUrl = _stringBuilder.AppendJoin('/', localAddress,
                    WebEncoders.Base64UrlEncode(id.ToByteArray())).ToString();

        await _urlRepository.CreateUrl(
             new Url
             {
                 Id = id,
                 ShortUrl = shortUrl,
                 LongUrl = longUrl
             });

        return shortUrl;
    }
}