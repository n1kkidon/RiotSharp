using System;
using System.Collections.Generic;
using System.Text;

namespace RiotSharp.Endpoints.ChallengesEndpoint
{
    [Serializable]
    public class Challenges
    {
        public long id { get; set; }
        public Dictionary<string, Locale> localizedNames { get; set; }
        public string state { get; set; }
        public long startTimestamp { get; set; }
        public long endTimestamp { get; set; }
        public bool leaderboard { get; set; }
        public Percentiles thresholds { get; set; }
    }

    [Serializable]
    public class Locale
    {
        public string description { get; set; }
        public string name { get; set; }
        public string shortDescription { get; set; }
    }
}
