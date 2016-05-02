using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Services
{
    public class TokenService
    {
        private TokenDto _Token;

        public TokenDto Token
        {
            get { return _Token; }
            set { _Token = value; }
        }

        public TokenErrorDto _TokenError;

        public TokenErrorDto TokenError
        {
            get { return _TokenError; }
            set { _TokenError = value; }
        }

        public async Task<bool> getTokenForLoginAsync(string username, string password)
        {
            var gotToken = false;
            using (var hClient = new HttpClient())
            {
                hClient.BaseAddress = new Uri("http://localhost:54390");

                var response = await hClient.PostAsync("token", new StringContent(string.Format("grant_type=password&username={0}&password={1}", username, password)));
                var tokenResponse = response.Content.ReadAsStringAsync().Result;
                if (response.IsSuccessStatusCode)
                {
                    _Token = JsonConvert.DeserializeObject<TokenDto>(tokenResponse);
                    gotToken = true;
                }
                else
                {
                    _TokenError = JsonConvert.DeserializeObject<TokenErrorDto>(tokenResponse);
                    gotToken = false;
                }
            }
            return gotToken;
        }
    }
    public class TokenDto
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public int expires_in { get; set; }
        public string userName { get; set; }
        [JsonProperty(".issued")]
        public DateTime issued { get; set; }
        [JsonProperty(".expires")]
        public DateTime expires { get; set; }
    }
    public class TokenErrorDto
    {
        public string error { get; set; }
        public string error_description { get; set; }
    }
}
