using Google.Apis.Services;
using Google.Apis.Urlshortener.v1;
using Google.Apis.Urlshortener.v1.Data;
using _4PBot.Model.Constants;

namespace _4PBot.Model.Helper
{
    public static class UrlShortener
    {
        public static string GetShortUrl(this string longUrl)
        {
            var url = new Url()
            {
                LongUrl = longUrl
            };
            var clientService = new BaseClientService.Initializer
            {
                ApiKey = Identity.GoogleApiKey
            };
            var returnValue = new UrlshortenerService(clientService).Url.Insert(url).Execute();
            return returnValue.Id;
        }
    }
}