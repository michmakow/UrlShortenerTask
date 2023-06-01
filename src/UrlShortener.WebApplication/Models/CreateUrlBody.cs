using System.ComponentModel.DataAnnotations;

namespace UrlShortener.WebApplication.Models;

public class CreateUrlBody
{
    [Required]
    public string LongUrl { get; set; }
}