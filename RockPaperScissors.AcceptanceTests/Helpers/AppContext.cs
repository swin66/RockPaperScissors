using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.SelfHost;
using Newtonsoft.Json;
using NUnit.Framework;
using RockPaperScissors.Web.App_Start;

namespace RockPaperScissors.AcceptanceTests.Helpers
{
    public class AppContext
    {
        private HttpServer _server;
        private HttpClient _client;

        public const string BaseUrl = "http://selfhostapi.com/"; // this can anything
        public const string ApiUrl = BaseUrl + "api/";

        public HttpServer Server
        {
            get
            {
                if (_server == null) BuildServer();
                return _server;
            }
        }

        public HttpClient Client
        {
            get
            {
                if (_client == null) BuildClient();
                return _client;
            }
        }

        public HttpResponseMessage LastResponse { get; private set; }
        public HttpError LastError { get; set; }

        public AppContext()
        {
            BuildServer();
            BuildClient();
        }


        private void BuildServer()
        {
            Console.WriteLine("Building server");

            var baseUri = new Uri(BaseUrl);
            var config = new HttpSelfHostConfiguration(baseUri) { IncludeErrorDetailPolicy = IncludeErrorDetailPolicy.Always };
            WebApiConfig.Register(config);
            GlobalConfiguration.Configuration.DependencyResolver = config.DependencyResolver;

            _server = new HttpSelfHostServer(config);
        }

        private void BuildClient()
        {
            Console.WriteLine("Building client");
            _client = new HttpClient(Server);
        }

        public void Dispose()
        {
            if (Server != null)
            {
                Server.Dispose();
            }
        }

        public T GetService<T>()
        {
            return (T)GlobalConfiguration.Configuration.DependencyResolver.GetService(typeof(T));
        }

        public HttpResponseMessage Get(string url)
        {
            Console.WriteLine("Getting {0}", url);

            using (var request = CreateRequest(url, "application/json", HttpMethod.Get))
            {
                LastResponse = null;

                using (var task = Client.SendAsync(request))
                {
                    try
                    {
                        LastResponse = task.Result;
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail("Exception: " + ex.Message);
                    }
                }
            }

            return LastResponse;
        }

        public HttpResponseMessage Post<T>(string url, T content) where T : class
        {
            Console.WriteLine("Getting {0}", url);

            using (var request = CreateRequest<T>(url, "application/json", HttpMethod.Post, content, new JsonMediaTypeFormatter()) )
            {
                LastResponse = null;

                using (var task = Client.SendAsync(request))
                {
                    try
                    {
                        LastResponse = task.Result;
                    }
                    catch (Exception ex)
                    {
                        Assert.Fail("Exception: " + ex.Message);
                    }
                }
            }

            return LastResponse;
        }


        public HttpRequestMessage CreateRequest(string url, string mthv, HttpMethod method, string urlPrefix = ApiUrl)
        {
            var request = new HttpRequestMessage { RequestUri = new Uri(urlPrefix + url) };

            request.Headers.Accept.Add(new MediaTypeWithQualityHeaderValue(mthv));
            request.Method = method;

            return request;
        }

        public HttpRequestMessage CreateRequest<T>(string url, string mthv, HttpMethod method, T content, MediaTypeFormatter formatter) where T : class
        {
            var request = CreateRequest(url, mthv, method);
            request.Content = new ObjectContent<T>(content, formatter);

            return request;
        }

        public T GetTypedContent<T>()
        {
            if (LastResponse == null || LastResponse.Content == null) return default(T);

            var json = LastResponse.Content.ReadAsStringAsync().Result;

            try
            {
                var responseType = JsonConvert.DeserializeObject<T>(json);
                return responseType;
            }
            catch (Exception)
            {
                Console.WriteLine("Failed to deserialise json from {0}", json);
                throw;
            }
        }

    }
}
