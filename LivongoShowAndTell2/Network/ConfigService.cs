using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LivongoShowAndTell2.Network
{
    public class ConfigService
    {
        public async Task<Config> GetConfig()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://api.mystrength.com");
                client.Timeout = TimeSpan.FromSeconds(15);

                //TODO: THis is where we get the first part of the URL
                
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var relativeUrl = "config?useNewFormat=true";
                var response = await client.GetAsync(relativeUrl);
                var responseStr = await response.Content.ReadAsStringAsync();
                var responseEntity = JsonConvert.DeserializeObject<Config>(responseStr);
                return responseEntity;
            }
        }
    }   
}
