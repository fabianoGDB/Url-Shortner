namespace UrlShortner.UrlHelpers
{
    public interface IUrlHelper
    {
        string ContructUrl(string shortcode);
        string GenerateShortCode();
        bool IsValidUrl(string url);
    }
}
