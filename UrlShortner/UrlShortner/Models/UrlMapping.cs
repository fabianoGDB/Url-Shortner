﻿namespace UrlShortner.Models
{
    public class UrlMapping
    {
        public int Id { get; set; }
        public string OriginUrl { get; set; } = string.Empty;
        public string ShortCode { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
