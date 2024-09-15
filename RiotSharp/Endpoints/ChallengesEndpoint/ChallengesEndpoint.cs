using RiotSharp.Http.Interfaces;
using RiotSharp.Misc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using RiotSharp.Endpoints.Interfaces;

namespace RiotSharp.Endpoints.ChallengesEndpoint
{
    public class ChallengesEndpoint : IChallengesEndpoint
    {
        private const string ChallengesRootUrl = "/lol/challenges/v1";
        private const string Percentiles = "/challenges/percentiles";
        private const string Config = "/challenges/config";
        private const string ChallengeConfig = "/challenges/{0}/config"; //id
        private const string TopPlayersByLevel = "/challenges/{0}/leaderboards/by-level/{1}"; //id, level
        private const string PercentileById = "/challenges/{0}/percentiles"; //id
        private const string InfoByPuuid = "/player-data/{0}"; //puuid

        private readonly IRateLimitedRequester _requester;

        public ChallengesEndpoint(IRateLimitedRequester requester)
        {
            _requester = requester;
        }

        public async Task<List<Challenges>> GetChallengesConfigAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(ChallengesRootUrl + Config, region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<Challenges>>(json);
        }

        public async Task<Dictionary<string, Percentiles>> GetPercentilesAsync(Region region)
        {
            var json = await _requester.CreateGetRequestAsync(ChallengesRootUrl + Percentiles, region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<Dictionary<string, Percentiles>>(json);
        }

        public async Task<Challenges> GetChallengeConfigByIdAsync(Region region, long id)
        {
            var json = await _requester.CreateGetRequestAsync(ChallengesRootUrl + string.Format(ChallengeConfig, id), region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<Challenges>(json);
        }

        /// <summary>
        /// Has to be master, grandmaster or challenger rank
        /// </summary>
        /// <param name="region"></param>
        /// <param name="id"></param>
        /// <param name="rank"></param>
        /// <param name="limit"></param>
        /// <returns></returns>
        public async Task<List<SummonerLeaderboardPosition>> GetTopPlayersForLevelAsync(Region region, long id, Rank rank, int? limit = null)
        {
            string level = Enum.GetName(typeof(Rank), rank).ToUpper();
            var args = new List<string>();
            if (limit != null)
                args.Add($"limit={Math.Abs(limit.Value)}");
            var json = await _requester.CreateGetRequestAsync(ChallengesRootUrl + string.Format(TopPlayersByLevel, id, level), region, args);
            return JsonConvert.DeserializeObject<List<SummonerLeaderboardPosition>>(json);
        }

        public async Task<Percentiles> GetRankPercentilesOfChallengeAsync(Region region, long id)
        {
            var json = await _requester.CreateGetRequestAsync(ChallengesRootUrl + string.Format(PercentileById, id), region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<Percentiles>(json);
        }

        public async Task<PlayerChallengesData> GetPlayerChallengesDataAsync(Region region, string puuid)
        {
            var json = await _requester.CreateGetRequestAsync(ChallengesRootUrl + string.Format(InfoByPuuid, puuid), region).ConfigureAwait(false);
            return JsonConvert.DeserializeObject<PlayerChallengesData>(json);
        }
    }
}
