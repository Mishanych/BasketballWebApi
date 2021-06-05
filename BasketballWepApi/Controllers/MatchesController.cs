using BasketballWebApi.Clients;
using BasketballWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Context;

namespace BasketballWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MatchesController : ControllerBase
    {


        private readonly ILogger<MatchesController> _logger;
        private readonly MatchesClient _matchesClient;
        private readonly ApplicationContext _dbContext;

        public MatchesController(ILogger<MatchesController> logger, MatchesClient matchesClient, ApplicationContext dbContext)
        {
            _logger = logger;
            _matchesClient = matchesClient;
            _dbContext = dbContext;
        }

        [HttpGet("date/{leagueId}/{dateRow}")]
        public async Task<List<MatchData>> GetAllMatchesByDate(string dateRow, string leagueId)
        {
            var matches = await _matchesClient.GetAllMatchesByDate(dateRow, leagueId);
            var allData = matches.data;
            List<MatchData> responses = new List<MatchData>();
            for (int i = 0; i < allData.Count(); i++)
            {
                responses.Add(new MatchData
                {
                    matchId = matches.data[i].matchId,
                    leagueId = matches.data[i].leagueId,
                    leagueName = matches.data[i].leagueName,
                    quarterCount = matches.data[i].quarterCount,
                    matchTime = matches.data[i].matchTime,
                    status = matches.data[i].status,
                    quarterRemainTime = matches.data[i].quarterRemainTime,
                    homeName = matches.data[i].homeName,
                    awayName = matches.data[i].awayName,
                    homeScore = matches.data[i].homeScore,
                    awayScore = matches.data[i].awayScore,
                    leagueSeason = matches.data[i].leagueSeason,
                    matchType = matches.data[i].matchType,
                    roundType = matches.data[i].roundType,
                    group = matches.data[i].group
                });
            }

            foreach (var response in matches.data)
            {
                try
                {
                    await _dbContext.MatchesData.AddAsync(response);

                    foreach (var league in _dbContext.LeaguesData)
                    {
                        if (league.leagueId == response.leagueId)

                            league.Matches.Add(response);
                    }
                    await _dbContext.SaveChangesAsync();
                }
                catch { }
            }

            return responses;
        }


        [HttpGet]
        [Route("id/{leagueId}")]
        public async Task<List<MatchData>> GetAllMatchesByLeagueId(string leagueId)
        {
            var matches = await _matchesClient.GetAllMatchesByLeagueId(leagueId);
            var allData = matches.data;
            List<MatchData> responses = new List<MatchData>();
            for (int i = 0; i < allData.Count(); i++)
            {
                responses.Add(new MatchData
                {
                    matchId = matches.data[i].matchId,
                    leagueId = matches.data[i].leagueId,
                    leagueName = matches.data[i].leagueName,
                    quarterCount = matches.data[i].quarterCount,
                    matchTime = matches.data[i].matchTime,
                    status = matches.data[i].status,
                    quarterRemainTime = matches.data[i].quarterRemainTime,
                    homeName = matches.data[i].homeName,
                    awayName = matches.data[i].awayName,
                    homeScore = matches.data[i].homeScore,
                    awayScore = matches.data[i].awayScore,
                    leagueSeason = matches.data[i].leagueSeason,
                    matchType = matches.data[i].matchType,
                    roundType = matches.data[i].roundType,
                    group = matches.data[i].group
                });
            }
            foreach (var response in matches.data)
            {
                try
                {
                    await _dbContext.MatchesData.AddAsync(response);

                    foreach (var league in _dbContext.LeaguesData)
                    {
                        if (league.leagueId == response.leagueId)

                            league.Matches.Add(response);
                    }

                    await _dbContext.SaveChangesAsync();
                }
                catch { }
            }
            return responses;
        }
    }
}

