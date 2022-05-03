using BitMexAPI.Requests.Rest;
using Serilog;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BitMexAPI.Rest
{
    public class BitmexRestClient : IDisposable
    {
        private string domain = "https://www.bitmex.com";
        private string testDomain = "https://testnet.bitmex.com";

        private readonly HttpClient httpClient;

        private readonly string _apiKey;
        private readonly string _apiSecret;

        private static readonly string API_KEY = "Pzyl8N6APkJAYh1595Tj-K5R";
        private static readonly string API_SECRET = "QLMXw_AxUkJduLRycPmvBn_JPYBOzv_-TrA0nDuHGGmdWgBX";

        public BitmexRestClient(string apiKey, string apiSecret)
        {
            _apiKey = apiKey;
            _apiSecret = apiSecret;

            httpClient = new HttpClient();

            httpClient.BaseAddress = new Uri(domain);
            httpClient.DefaultRequestHeaders.Add("api-key", _apiKey ?? string.Empty);
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/xml"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/xml"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/javascript"));
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));          
        }

        public async Task<string> ExecuteHttp(RestRequestBase request)
        {
            if (request.RequiresAuth)
            {
                string expires = GetExpires().ToString();
                string message = $"{request.Method}{request.Path}{expires}{request.Json?.ToString()}";
                //string message = $"{request.Method}{request.Path}{expires}" + "";
                byte[] signatureBytes = Hmacsha256(Encoding.UTF8.GetBytes(_apiSecret), Encoding.UTF8.GetBytes(message));
                string signatureString = ByteArrayToString(signatureBytes);

                request.Headers.Add("api-expires", expires);
                request.Headers.Add("api-signature", signatureString);
            }

            var response = await httpClient.SendAsync(request);
            //Log.Debug(await response.Content.ReadAsStringAsync());
            return await response.Content.ReadAsStringAsync();
        }

        private long GetExpires()
        {
            return DateTimeOffset.UtcNow.ToUnixTimeSeconds() + 3600; // set expires one hour in the future
        }

        private byte[] Hmacsha256(byte[] keyByte, byte[] messageBytes)
        {
            using (var hash = new HMACSHA256(keyByte))
            {
                return hash.ComputeHash(messageBytes);
            }
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}