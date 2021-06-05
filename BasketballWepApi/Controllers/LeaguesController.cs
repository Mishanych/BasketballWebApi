using BasketballWebApi.Clients;
using BasketballWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Context;

namespace BasketballWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaguesController : ControllerBase
    {
        

        private readonly ILogger<LeaguesController> _logger;
        private readonly LeaguesClient _leaguesClient;
        private readonly ApplicationContext _dbContext;
        public LeaguesController(ILogger<LeaguesController> logger, LeaguesClient leaguesClient, ApplicationContext dbContext)
        {
            _logger = logger;
            _leaguesClient = leaguesClient;
            _dbContext = dbContext;
        }

        [HttpGet]
        public async Task<List<LeagueData>> GetAllLeagues()
        {
            var leagues = await _leaguesClient.GetAllLeagues();
            var allData = leagues.data;
            List<LeagueData> responses = new List<LeagueData>();
            for (int i = 0; i < allData.Count(); i++)
            {
                responses.Add(new LeagueData
                {
                    leagueId = leagues.data[i].leagueId,
                    leagueName = leagues.data[i].leagueName,
                    leagueShortName = leagues.data[i].leagueShortName,
                    leagueKind = leagues.data[i].leagueKind
                });
            }

            foreach (var response in leagues.data)
            {
                try
                {
                    await _dbContext.LeaguesData.AddAsync(response);
                    await _dbContext.SaveChangesAsync();
                }
                catch { }
            }
            return responses;
        }



        [HttpGet("{id}")]
        public async Task<LeaguesResponse> GetLeagueById(int id)
        {
            var league = await _leaguesClient.GetLeagueById(id);

            var result = new LeaguesResponse
            {
                leagueName = league.data.FirstOrDefault().leagueName,
                leagueShortName = league.data.FirstOrDefault().leagueShortName,
                leagueKind = league.data.FirstOrDefault().leagueKind
            };

            return result;
        }
    }
}
