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
    public class PlayersClient
    {
        private HttpClient _client;
        private static string _address;
        private static string _apiKey;

        public PlayersClient()
        {
            _client = new HttpClient();
            _address = Constants.address;
            _apiKey = Constants.apiKey;

            _client.BaseAddress = new Uri(_address);
        }

        public async Task<Player> GetPlayerByName(string name)
        {
            var response = await _client.GetAsync($"player/search?api_key={_apiKey}&name={name}");
            response.EnsureSuccessStatusCode();

            var content = response.Content.ReadAsStringAsync().Result;

            var result = JsonConvert.DeserializeObject<Player>(content);

            return result;

        }


        public async Task<Player> GetAllPlayers()
        {
            var response = await _client.GetAsync($"player?api_key={_apiKey}");
            response.EnsureSuccessStatusCode();
            var content = response.Content.ReadAsStringAsync().Result;
            var result = JsonConvert.DeserializeObject<Player>(content);

            return result;
        }
    }
}
