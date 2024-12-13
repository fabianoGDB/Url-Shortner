using Microsoft.EntityFrameworkCore;
using UrlShortner.Data;
using UrlShortner.Models;

namespace UrlShortner.Repository
{
    public class UrlRepository(AppDbContext context) : IUrlRepository
    {
        public async Task<UrlMapping> GetMappingByOriginalUrlAsync(string original)
        {
            return await context.UrlMappings.FirstOrDefaultAsync(x => x.OriginUrl == original);
        }

        public async Task<UrlMapping> GetMappingByShortCodeAsync(string shortcode)
        {
            return await context.UrlMappings.FirstOrDefaultAsync(x => x.ShortCode == shortcode);
        }

        public async Task SaveMappingAsync(UrlMapping mapping)
        {
            context.UrlMappings.Add(mapping);
            await context.SaveChangesAsync();
            return;
        }
    }
}
