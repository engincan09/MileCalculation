using System.Net.Http;
using System;

namespace MileCalculation.Api.Services.HttpService.BuilderPattern
{
    public class HttpClientBuilder
    {
        private HttpClient _httpClient = new HttpClient();
        private Uri _baseAddress;
        private TimeSpan _timeout = TimeSpan.FromSeconds(100);

        public HttpClientBuilder WithBaseAddress(Uri baseAddress)
        {
            _baseAddress = baseAddress;
            return this;
        }

        public HttpClientBuilder WithTimeout(TimeSpan timeout)
        {
            _timeout = timeout;
            return this;
        }

        public HttpClientBuilder WithDefaultHeaders()
        {
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
            return this;
        }

        public HttpClient Build()
        {
            _httpClient.BaseAddress = _baseAddress;
            _httpClient.Timeout = _timeout;
            _httpClient.DefaultRequestHeaders.Clear();
            return _httpClient;
        }
    }
}
