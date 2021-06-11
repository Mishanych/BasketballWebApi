using BasketballWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace BasketballWebApi.Clients
{
    public class MatchesClient
    {
        private HttpClient _client;
        private static string _address;
        private static string _apiKey;

        public MatchesClient()
        {
            _client = new HttpClient();
            _address = Constants.address;
            _apiKey = Constants.apiKey;

            _client.BaseAddress = new Uri(_address);
        }

        public async Task<Matches> GetAllMatchesByDate(string dateRow, string leagueId)
        {
            var response = await _client.GetAsync($"schedule?api_key={_apiKey}&date={dateRow}&leagueId={leagueId}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Matches>(content);

            return result;
        }

        public async Task<Matches> GetAllMatchesByLeagueId(string leagueId)
        {
            var response = await _client.GetAsync($"schedule?api_key={_apiKey}&leagueId={leagueId}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Matches>(content);

            return result;
        }

        public async Task<Matches> GetMatchById(string matchId)
        {
            var response = await _client.GetAsync($"schedule/basic?api_key={_apiKey}&matchId={matchId}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Matches>(content);
            return result;
        }
    }
}
