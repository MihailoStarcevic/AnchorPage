namespace AnchorPage.API.Core
{
    public class AppSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string JwtSecretKey { get; set; } = string.Empty;
        public string JwtIssuer { get; set; } = string.Empty;
    }
}
