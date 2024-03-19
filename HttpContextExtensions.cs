namespace Indotalent
{
    public static class HttpContextExtensions
    {
        public static string GetCurrentUrl(this HttpContext httpContext)
        {
            string baseUrl = $"{httpContext.Request.Scheme}://{httpContext.Request.Host}{httpContext.Request.PathBase}";
            string path = httpContext.Request.Path;
            string queryString = httpContext.Request.QueryString.ToUriComponent();
            return baseUrl + path + queryString;
        }
    }
}
