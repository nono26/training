namespace VolleyBall.Infrastructure
{
    public class MatchConfiguration{
        public IEnumerable<TeamConfiguration> TeamConfigurations;

    }
    public class TeamConfiguration{
        public string Id{get;set;}
        public int ProbabilityTeam{get;set;}
    }
}

