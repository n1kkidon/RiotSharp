using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ChallengesEndpoint
{
    public class SummonerLeaderboardPosition
    {
        [JsonProperty("position")]
        public int Position { get; set; }
        [JsonProperty("puuid")]
        public string Puuid { get; set; }
        [JsonProperty("value")]
        public long Value { get; set; }
    }
}
