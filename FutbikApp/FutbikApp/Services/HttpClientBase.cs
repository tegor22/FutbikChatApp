using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace FutbikApp.Services
{
    public class HttpClientBase
    {
        protected readonly HttpClient _client;
        protected string _apiUrl = "http://localhost:60187/";

        protected HttpClientBase()
        {
            _client = new HttpClient();
        }

    }
}
