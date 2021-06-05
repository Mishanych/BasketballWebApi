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
    public class TeamController : ControllerBase
    {
        

        private readonly ILogger<TeamController> _logger;
        private readonly TeamsClient _teamsClient;
        private readonly ApplicationContext _dbContext;

        public TeamController(ILogger<TeamController> logger, TeamsClient teamsClient, ApplicationContext dbContext)
        {
            _logger = logger;
            _teamsClient = teamsClient;
            _dbContext = dbContext;
        }

        [HttpGet("byLeagueId/{leagueId}")]
        public async Task<List<TeamResponse>> GetTeamsByLeagueId(int leagueId)
        {
            var teams = await _teamsClient.GetLeagueByLeagueId(leagueId);
            var allData = teams.data;
            List<TeamResponse> responses = new List<TeamResponse>();
            for (int i = 0; i < allData.Count(); i++)
            {
                responses.Add(new TeamResponse
                {
                    name = teams.data[i].name,
                    shortName = teams.data[i].shortName,
                    logo = teams.data[i].logo,
                    website = teams.data[i].website,
                    division = teams.data[i].division,
                    city = teams.data[i].city,
                    championCount = teams.data[i].championCount,
                    coach = teams.data[i].coach
                });
            }
            return responses;
        }

        [HttpGet("byName/{name}")]
        public async Task<List<TeamData>> GetTeamByName(string name)
        {
            var teams = await _teamsClient.GetTeamByName(name);
            var allData = teams.data;
            List<TeamData> responses = new List<TeamData>();
            for (int i = 0; i < allData.Count(); i++)
            {
                responses.Add(new TeamData
                {
                    teamId = teams.data[i].teamId,
                    leagueId = teams.data[i].leagueId,
                    name = teams.data[i].name,
                    shortName = teams.data[i].shortName,
                    logo = teams.data[i].logo,
                    website = teams.data[i].website,
                    division = teams.data[i].division,
                    conference = teams.data[i].conference,
                    city = teams.data[i].city,
                    venue = teams.data[i].venue,
                    capacity = teams.data[i].capacity,
                    joinYear = teams.data[i].joinYear,
                    championCount = teams.data[i].championCount,
                    coach = teams.data[i].coach
                });
            }
            foreach (var response in teams.data)
            {
                try
                {
                    await _dbContext.TeamsData.AddAsync(response);
                    await _dbContext.SaveChangesAsync();
                }
                catch { }
            }
            return responses;
        }

        [HttpGet]
        public async Task<List<TeamResponse>> GetAllTeams()
        {
            var teams = await _teamsClient.GetAllTeams();
            var allData = teams.data;
            List<TeamResponse> responses = new List<TeamResponse>();
            for (int i = 0; i < allData.Count(); i++)
            {
                responses.Add(new TeamResponse
                {
                    name = teams.data[i].name,
                    shortName = teams.data[i].shortName,
                    logo  = teams.data[i].logo,
                    website = teams.data[i].website,
                    division = teams.data[i].division,
                    city  = teams.data[i].city,
                    championCount = teams.data[i].championCount,
                    coach = teams.data[i].coach
                });
            }

            //foreach (var response in teams.data)
            //{
            //    await _dbContext.TeamsData.AddAsync(response);
            //}
            return responses;
        }
    }
}
