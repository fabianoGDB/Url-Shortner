using UrlShortner.Models;

namespace UrlShortner.Repository
{
    public interface IUrlRepository
    {
        Task<UrlMapping> GetMappingByShortCodeAsync(string shortcode);
        Task<UrlMapping> GetMappingByOriginalUrlAsync(string original);
        Task SaveMappingAsync(UrlMapping mapping);
    }

}
