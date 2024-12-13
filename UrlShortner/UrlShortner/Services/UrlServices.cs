using UrlShortner.Models;
using UrlShortner.Repository;
using UrlShortner.UrlHelpers;

namespace UrlShortner.Services
{
    public class UrlServices(IUrlRepository urlRepository, IUrlHelper urlHelper) : IUrlServices
    {
        public async Task<string?> GetOriginalUrlAsync(string shortUrl)
        {
            var check = await urlRepository.GetMappingByShortCodeAsync(shortUrl);
            if (check == null) { return ""; }

            return check.OriginUrl;
        }

        public async Task<string?> ShortenUrlAsync(string originalUrl)
        {
            bool validateUrl = urlHelper.IsValidUrl(originalUrl);
            if (!validateUrl) { return null!; }

            var checkMap = await urlRepository.GetMappingByOriginalUrlAsync(originalUrl);
            if (checkMap == null) {
                var shortcode = urlHelper.GenerateShortCode();
                var mapping = new UrlMapping
                {
                    ShortCode = shortcode,
                    OriginUrl = originalUrl
                };

                await urlRepository.SaveMappingAsync(mapping);  
                
                return urlHelper.ContructUrl(shortcode);
            }

            return urlHelper.ContructUrl(checkMap!.ShortCode);
        }
    }
}
