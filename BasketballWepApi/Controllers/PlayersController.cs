using BasketballWebApi.Clients;
using BasketballWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Context;

namespace BasketballWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        

        private readonly ILogger<PlayersController> _logger;
        private readonly PlayersClient _playersClient;
        private readonly ApplicationContext _dbContext;

        public PlayersController(ILogger<PlayersController> logger, PlayersClient playersClient, ApplicationContext dbContext)
        {
            _logger = logger;
            _playersClient = playersClient;
            _dbContext = dbContext;
        }

        [HttpGet("byName/{name}")]
        public async Task<List<PlayerData>> GetPlayerByName(string name)
        {
            var players = await _playersClient.GetPlayerByName(name);
            var allData = players.data;
            List<PlayerData> responses = new List<PlayerData>();
            for (int i = 0; i < allData.Count(); i++)
            {
                responses.Add(new PlayerData
                {
                    playerId = players.data[i].playerId,
                    number = players.data[i].number,
                    name = players.data[i].name,
                    teamId = players.data[i].teamId,
                    place = players.data[i].place,
                    birthday = players.data[i].birthday,
                    height = players.data[i].height,
                    weight = players.data[i].weight,
                    photo = players.data[i].photo,
                    nbaAge = players.data[i].nbaAge,
                    salary = players.data[i].salary,
                });
            }
            foreach (var response in players.data)
            {
                try
                {
                    await _dbContext.PlayersData.AddAsync(response);
                    await _dbContext.SaveChangesAsync();
                }
                catch { }
            }
            return responses;
        }

        [HttpGet]
        public async Task<List<PlayerResponse>> GetAllPlayers()
        {
            var players = await _playersClient.GetAllPlayers();
            var allData = players.data;
            List<PlayerResponse> responses = new List<PlayerResponse>();
            for (int i = 0; i < allData.Count(); i++)
            {
                responses.Add(new PlayerResponse
                {
                    number = players.data[i].number,
                    name = players.data[i].name,
                    place = players.data[i].place,
                    height = players.data[i].height,
                    weight = players.data[i].weight,
                    photo = players.data[i].photo, 
                    nbaAge = players.data[i].nbaAge
                });
            }

            return responses;
        }
    }
}
