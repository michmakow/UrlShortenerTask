using Microsoft.AspNetCore.Mvc;
using UrlShortener.Data.Services;
using UrlShortener.WebApplication.Models;

namespace UrlShortener.WebApplication.Controllers;

[Route("")]
public class UrlController : Controller
{
    private readonly ILogger<UrlController> _logger;
    private readonly IUrlService _urlService;

    public UrlController(ILogger<UrlController> logger, IUrlService urlService)
    {
        _logger = logger;
        _urlService = urlService;
    }

    [HttpGet]
    [Route("list")]
    public async Task<IActionResult> GetUrls()
    {
        _logger.LogDebug("List request");
        return Ok(await _urlService.GetUrls());
    }

    [HttpGet("/{shortUrl:required}")]
    public async Task<IActionResult> RedirectToLongUrl(string shortUrl)
    {
        _logger.LogDebug("Redirect request");
        if (shortUrl is null)
        {
            _logger.LogDebug("Request for getting urls");
            return BadRequest();
        }

        var url = await _urlService.GetUrl(shortUrl);
        if (url is null)
        {
            _logger.LogDebug("Request for getting urls");
            return NotFound();
        }

        _logger.LogDebug("Request for getting urls");
        return Redirect(url.LongUrl);
    }

    [HttpPost]
    [Route("")]
    public async Task<IActionResult> CreateUrl([FromBody] CreateUrlBody body)
    {
        if (body is null || body.LongUrl is null)
        {
            return BadRequest();
        }

        var localAddress = HttpContext.Request.Scheme + "://" + HttpContext.Request.Host.Value;
        return Ok(await _urlService.CreateUrl(body.LongUrl, localAddress));
    }
}