using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ChallengesEndpoint
{
    [Serializable]
    public class Percentiles
    {
        [JsonProperty("CHALLENGER")]
        public double Challenger { get; set; }
        [JsonProperty("GRANDMASTER")]
        public double Grandmaster { get; set; }
        [JsonProperty("MASTER")]
        public double Master { get; set; }
        [JsonProperty("DIAMOND")]
        public double Diamond { get; set; }
        [JsonProperty("PLATINUM")]
        public double Platinum { get; set; }
        [JsonProperty("GOLD")]
        public double Gold { get; set; }
        [JsonProperty("SILVER")]
        public double Silver { get; set; }
        [JsonProperty("BRONZE")]
        public double Bronze { get; set; }
        [JsonProperty("IRON")]
        public double Iron { get; set; }
        [JsonProperty("NONE")]
        public double None { get; set; }
    }
}
