namespace TelegramBotNet.Core
{
    using System.Collections.Specialized;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Threading.Tasks;

    public class RequestCore
    {
        public static async Task<string> Get(string method, string token, NameValueCollection args)
        {
            string url = $"{"https://api.telegram.org/bot"}{token}/{method}{ToQueryString(args)}";
            var client = new HttpClient();
            var response = await client.GetAsync(url);
            var responseContent = await response.Content.ReadAsStringAsync();
            return responseContent;
        }

        private static string ToQueryString(NameValueCollection nvc)
        {
            var array = (from key in nvc.AllKeys
                from value in nvc.GetValues(key)
                select $"{WebUtility.UrlEncode(key)}={WebUtility.UrlEncode(value)}")
                .ToArray();
            if (array.Any())
            {
                return "?" + string.Join("&", array);                
            }
            return "";
        }
    }
}