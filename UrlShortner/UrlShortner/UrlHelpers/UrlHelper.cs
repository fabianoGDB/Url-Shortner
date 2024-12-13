namespace UrlShortner.UrlHelpers
{
    public class UrlHelper(IHttpContextAccessor httpContextAccessor) : IUrlHelper
    {
        public string ContructUrl(string shortcode)
        {
            var request =  httpContextAccessor.HttpContext?.Request;
            var baseUrl = $"{request!.Scheme}://{request.Host}";
            return $"{baseUrl}{shortcode}";
        }

        public string GenerateShortCode()
        {
            return Guid.NewGuid().ToString("n")[..8];
        }

        public bool IsValidUrl(string url)
        {
            if(string.IsNullOrEmpty(url)) return false;
            
            return Uri.TryCreate(url, UriKind.Absolute, out var uri) && (uri.Scheme == Uri.UriSchemeHttp || uri.Scheme == Uri.UriSchemeFtp);
        }
    }
}
