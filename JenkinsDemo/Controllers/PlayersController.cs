using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using jenkinsDemo.Models;

namespace jenkinsDemo.Controllers
{
    [ApiController]
    [Route("api/v1/players")]
    public class PlayersController : ControllerBase
    {
        private readonly IBallDontLieManager _manager;

        public PlayersController(IBallDontLieManager manager)
        {
            _manager = manager;
        }

        [HttpGet]
        public IEnumerable<Player> GetPlayers(string teamName = null)
        {
            IEnumerable<Player> players;
            
            if (string.IsNullOrEmpty(teamName))
            {
                players = _manager.GetPlayers();
            }
            else
            {
                players = _manager.GetPlayers().Where(p =>
                {
                    if (p.team != null)
                    {
                        return p.team.full_name.ToLower().Contains(teamName.ToLower()) ||
                               p.team.abbreviation.ToLower().Contains(teamName.ToLower()) ||
                               p.team.city.ToLower().Contains(teamName.ToLower()) ||
                               p.team.name.ToLower().Contains(teamName.ToLower());
                    }

                    return false;
                });
            }
            
            return players;
        }
    }
}