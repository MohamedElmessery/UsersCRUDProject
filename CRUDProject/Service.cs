﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace CRUDProject
{
    public static class Service
    {
        public static HttpClient WebApiClient = new HttpClient();
       static Service()
        {
            WebApiClient.BaseAddress = new Uri("http://localhost:50674/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}