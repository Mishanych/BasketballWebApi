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
    public class TeamsClient
    {
        private HttpClient _client;
        private static string _address;
        private static string _apiKey;

        public TeamsClient()
        {
            _client = new HttpClient();
            _address = Constants.address;
            _apiKey = Constants.apiKey;

            _client.BaseAddress = new Uri(_address);
        }

        public async Task<Team> GetLeagueByLeagueId(int leagueId)
        {
            var response = await _client.GetAsync($"team?api_key={_apiKey}&leagueId={leagueId}");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<Team>(content);

            return result;

        }

        public async Task<Team> GetTeamByName(string name)
        {
            var response = await _client.GetAsync($"team/search?api_key={_apiKey}&name={name}");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<Team>(content);

            return result;

        }

        public async Task<Team> GetAllTeams()
        {
            var response = await _client.GetAsync($"team?api_key={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Team>(content);

            return result;
        }
    }
}
