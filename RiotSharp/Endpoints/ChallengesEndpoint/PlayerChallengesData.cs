using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace RiotSharp.Endpoints.ChallengesEndpoint
{
    public class PlayerChallengesData
    {
        [JsonProperty("totalPoints")]
        public PointData TotalPoints { get; set; }
        [JsonProperty("categoryPoints")]
        public Categories CategoryPoints { get; set; }
        [JsonProperty("challenges")]
        public List<Challenge> Challenges { get; set; }
        [JsonProperty("preferences")]
        public Preferences UserPreferences { get; set; }
    }

    public class Preferences
    {
        [JsonProperty("bannerAccent")]
        public string BannerAccent { get; set; }
        [JsonProperty("title")]
        public string TitleId { get; set; }
        [JsonProperty("challengeIds")]
        public List<long> ChallengeIds { get; set; }
    }
    public class Challenge
    {
        [JsonProperty("challengeId")]
        public long ChallengeId { get; set; }
        [JsonProperty("percentile")]
        public double Percentile { get; set; }
        [JsonProperty("level")]
        public string Level { get; set; }
        [JsonProperty("value")]
        public long Value { get; set; }
        [JsonProperty("achievedTime")]
        public long AchievedTime { get; set; }
    }

    public class Categories
    {
        [JsonProperty("TEAMWORK")]
        public PointData Teamwork { get; set; }
        [JsonProperty("EXPERTISE")]
        public PointData Expertise { get; set; }
        [JsonProperty("VETERANCY")]
        public PointData Veterancy { get; set; }
        [JsonProperty("COLLECTION")]
        public PointData Collection { get; set; }
        [JsonProperty("IMAGINATION")]
        public PointData Imagination { get; set; }
    }
    public class PointData
    {
        [JsonProperty("level")]
        public string Level { get; set; }
        [JsonProperty("current")]
        public long Current { get; set; }
        [JsonProperty("max")]
        public long Max { get; set; }
        [JsonProperty("percentile")]
        public double Percentile { get; set; }
    }
}
