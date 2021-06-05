using BasketballWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BasketballWebApi.Clients
{
    public class LeaguesClient
    {
        private HttpClient _client;
        private static string _address;
        private static string _apiKey;

        public LeaguesClient()
        {
            _client = new HttpClient();
            _address = Constants.address;
            _apiKey = Constants.apiKey;

            _client.BaseAddress = new Uri(_address);
        }

        public async Task<Leagues> GetAllLeagues()
        {
            var response = await _client.GetAsync($"league/basic?api_key={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Leagues>(content);

            return result;
        }

        public async Task<Leagues> GetLeagueById(int id)
        {
            var response = await _client.GetAsync($"league?api_key={_apiKey}&leagueId={id}");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<Leagues>(content);

            return result;

        }
    }
}
