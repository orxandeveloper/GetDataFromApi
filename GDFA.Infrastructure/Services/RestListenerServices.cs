using GDFA.Application.Config;
using GDFA.Application.IServices;
using GDFA.Application.Model;
using Microsoft.Extensions.Options;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace GDFA.Infrastructure.Services
{
    public class RestListenerServices : IRestListenerService
    {

        private readonly IOptions<PostRestConfig> _restConfig;
        private readonly HttpClient _postClient;
        
        public RestListenerServices(IOptions<PostRestConfig> restConfig, IHttpClientFactory clientFactory)
        {
            _restConfig = restConfig;
            _postClient = clientFactory.CreateClient("posts");
            _postClient.BaseAddress = new Uri(restConfig.Value.BaseUrl);
        }
        public async Task<Post> PostAsync()
        {
            Post postResponse = null;

            var request = new object();

            var httpContent = new StringContent(JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            var response = await _postClient.PostAsync(_restConfig.Value.BaseUrl, httpContent);

            var result = await response.Content.ReadAsStringAsync();

            if (response.StatusCode == HttpStatusCode.OK)
            {
                System.IO.File.WriteAllText(@"JsonFile\Test.json", result);

                postResponse = JsonConvert.DeserializeObject<Post>(result);
            }

            else
                throw new Exception($"{response.StatusCode} : {result} ");

            return postResponse;
        }
    }
}
