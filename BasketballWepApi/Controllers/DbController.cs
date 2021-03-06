using BasketballWebApi.Controllers;
using BasketballWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WebApi.Context;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DbController : ControllerBase
    {
        private readonly ILogger<DbController> _logger;
        private readonly ApplicationContext _dbContext;
        private readonly LeaguesController _leaguesController;
        private readonly MatchesController _matchesController;
        private readonly TeamController _teamController;
        private readonly PlayersController _playersController;

        public DbController(ILogger<DbController> logger, ApplicationContext dbContext, LeaguesController leaguesController,
                                                                                        MatchesController matchesController,
                                                                                        TeamController teamController,
                                                                                        PlayersController playersController)
        {
            _logger = logger;
            _dbContext = dbContext;
            _leaguesController = leaguesController;
            _matchesController = matchesController;
            _teamController = teamController;
            _playersController = playersController;
        }

        #region Leagues


        [HttpGet]
        [Route("leagues/{leagueName}")]
        public async Task<LeagueData> GetLeagueByName(string leagueName)
        {
            leagueName = leagueName.ToUpper();
            var result = await _dbContext.LeaguesData.FindAsync(leagueName);

            if(result != null)
            {
                return result;
            }
            else
            {
                await _leaguesController.GetAllLeagues();
                result = await _dbContext.LeaguesData.FindAsync(leagueName);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }


        #endregion

        #region Teams


        [HttpGet]
        [Route("teams/{teamName}")]
        public async Task<TeamData> GetTeamByName(string teamName)
        {
            teamName = teamName.ToLower();
            CultureInfo cultureInfo = Thread.CurrentThread.CurrentCulture;

            TextInfo text = cultureInfo.TextInfo;
            var team = text.ToTitleCase(teamName);

            var result = await _dbContext.TeamsData.FindAsync(team);
            if (result != null)
            {
                return result;
            }
            else
            {
                await _teamController.GetTeamByName(teamName);
                result = await _dbContext.TeamsData.FindAsync(team);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }




        #endregion

        #region Players


        [HttpGet]
        [Route("players/{playerName}")]
        public async Task<PlayerData> GetPlayerByName(string playerName)
        {
            var result = FindPlayer(playerName);
            //var result = await _dbContext.PlayersData.FindAsync(playerName);
            if (result != null)
            {
                return result;
            }
            else
            {
                await _playersController.GetPlayerByName(playerName);
                result = await _dbContext.PlayersData.FindAsync(playerName);
                if (result != null)
                {
                    return result;
                }
                else
                {
                    return null;
                }
            }
        }

        private PlayerData FindPlayer(string playerName)
        {
            foreach (var player in _dbContext.PlayersData)
            {
                if (player.name.ToLower().Contains(playerName.ToLower()))
                {
                    return player;
                }
            }
            return null;
        }


        #endregion

        #region Matches


        [HttpGet]
        [Route("games/{leagueName}/{matchDate}")]
        public async Task<List<MatchData>> GetMatchByLeagueAndDate(string leagueName, string matchDate)
        {
            if (!_dbContext.LeaguesData.Any())
            {
                await _leaguesController.GetAllLeagues();
            }
            string leagueId = string.Empty;
            foreach (var league in _dbContext.LeaguesData)
            {
                if (league.leagueName.ToLower() == leagueName.ToLower() || league.leagueShortName.ToLower() == leagueName.ToLower())
                {
                    leagueId = league.leagueId;
                    break;
                }
            }
            if (leagueId == null)
            {
                return null;
            }
            return await _matchesController.GetAllMatchesByDate(matchDate, leagueId);
            
        }


        [HttpGet]
        [Route("game/{matchId}")]
        public async Task<MatchData> FindMatch(string matchId)
        {
            
            var result = await _dbContext.MatchesData.FindAsync(matchId);

            if(result == null)
            {
                result = await _matchesController.GetMatchById(matchId);
                if(result == null)
                {
                    return null;
                }
            }

            return result;
        }
        

        #endregion


    }
}
