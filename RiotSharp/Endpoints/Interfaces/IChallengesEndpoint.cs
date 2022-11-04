using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using RiotSharp.Endpoints.ChallengesEndpoint;
using RiotSharp.Misc;

namespace RiotSharp.Endpoints.Interfaces
{
    public interface IChallengesEndpoint
    {
        Task<List<Challenges>> GetChallengesConfigAsync(Region region);

        Task<Dictionary<string, Percentiles>> GetPercentilesAsync(Region region);

        Task<Challenges> GetChallengeConfigByIdAsync(Region region, long id);

        /// <summary>
        /// Has to be master, grandmaster or challenger rank
        /// </summary>
        /// <param name="region"></param>
        /// <param name="id"></param>
        /// <param name="rank"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        Task<List<SummonerLeaderboardPosition>> GetTopPlayersForLevelAsync(Region region, long id, Rank rank, int? limit = null);

        Task<Percentiles> GetRankPercentilesOfChallengeAsync(Region region, long id);

        Task<PlayerChallengesData> GetPlayerChallengesDataAsync(Region region, string puuid);
    }
}
