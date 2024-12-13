namespace UrlShortner.Services
{
    public interface IUrlServices
    {
        Task<string?> ShortenUrlAsync(string originalUrl);
        Task<string?> GetOriginalUrlAsync(string shortUrl);
    }
}
