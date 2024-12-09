using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;

namespace api.Services;
    public class SmhiService
    {
        private readonly HttpClient _httpClient;
    }

    public SmhiService (HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<string> GetOceanographicDataAsync()
    {
        string url = "https://opendata-download-ocobs.smhi.se/api/version/latest.json";

    }
    