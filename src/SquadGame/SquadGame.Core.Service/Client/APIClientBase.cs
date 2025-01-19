using RestSharp;
using SquadGame.Api.Base.Configurations;

namespace SquadGame.Core.Service.Client
{
    public abstract class APIClientBase
    {
        private readonly SquadApiConfigurations _configuration;

        // Constructor with dependency injection
        protected APIClientBase(SquadApiConfigurations configuration)
        {
            // Initialize the private fields
            _configuration = configuration;
        }
        protected string GetBaseUrl()
        {
            var uriBuilder = new UriBuilder
            {
                Scheme = Uri.UriSchemeHttps,
                Host = _configuration.Host
            };

            return uriBuilder.Uri.ToString();
        }

        protected string GetApiKey()
        {
            return _configuration.ApiKey;
        }

        protected string GetHost()
        {
            return _configuration.Host;
        }

        protected IRestRequest CreateRequest(string uri, object? body = null, Method method = Method.GET)
        {
            var requestApi = new RestRequest(uri, DataFormat.Json)
            {
                OnBeforeDeserialization = resp =>
                {
                    resp.ContentType = "application/json";
                },
                Method = method
            };

            requestApi.AddHeader("x-rapidapi-host", GetHost());
            requestApi.AddHeader("x-rapidapi-key", GetApiKey());

            if(body is not null)
                requestApi.AddJsonBody(body);

            return requestApi;
        }
    }
}
