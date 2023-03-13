using System.Net.Http.Headers;
using System.Net.Http;
using System.Threading.Tasks;
using System;
using MileCalculation.Api.Services.HttpService.Enums;
using MileCalculation.Api.Services.HttpService.BuilderPattern;
using System.Text.Json;
using System.Text;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using MileCalculation.Api.Helpers.MileCalculator.Dto;

namespace MileCalculation.Api.Services.HttpService
{

    public class CustomConnection
    {
        static Uri uri;
        static HttpClient client;
        public CustomConnection(UriType uriType, bool prod = true)
        {
            var builder = new HttpClientBuilder();
  
            if (prod)
            {
                switch (uriType)
                {
                    case UriType.CTeleport:
                        uri = new Uri("https://places-dev.cteleport.com/airports/");
                        break;
                }
            }
            else
            {
                switch (uriType)
                {
                    case UriType.CTeleport:
                        uri = new Uri("https://places-dev.cteleport.com/airports/");
                        break;
                }
            }

             client = builder.WithBaseAddress(uri)
                            .WithTimeout(TimeSpan.FromSeconds(30))
                            .WithDefaultHeaders()
                            .Build();
        }

        public async Task<ResponseInfo> Get(string requestUri)
        {         

            HttpResponseMessage response = await client.GetAsync(requestUri).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {

                    var sonuc = await response.Content.ReadFromJsonAsync<ResponseInfo>();
                    return sonuc;        
            }
            else
                return null;
        }  

    }
}


