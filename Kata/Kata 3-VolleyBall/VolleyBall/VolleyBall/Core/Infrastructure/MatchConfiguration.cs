namespace VolleyBall.Infrastructure
{
    public class MatchConfigurationOptions{

        public const string MatchConfiguration= "MatchConfiguration";
        public List<TeamConfiguration> TeamConfigurations{get;set;}

    }
    public class TeamConfiguration{
        public string Id{get;set;}
        public int ProbabilityTeam{get;set;}
    }
}

