using Serilog;
using Microsoft.Extensions.Options;
using VolleyBall.Infrastructure;

namespace VolleyBall.Core
{
    public class Match : IMatch
    {
        private Score Score{get;set;}
        private string _currentTeamServicingId{get;set;}
        public Match(IOptions<MatchConfiguration> config){
            var teams= new List<Team>();
            foreach(TeamConfiguration teamConfig in config.Value.TeamConfigurations){
                teams.Add(new Team(teamConfig.Id, teamConfig.ProbabilityTeam));
            }
            Score= new Score(teams);

        }

        public void PlayMatch(){
            Log.Information("Volleyball match begins");

            while(Score.IsMatchNotFinished()){
                PlaySet();
            } 

            Log.Information("Match Finished");
        }

        private void PlaySet(){    
            Score.NewSet();
            while(Score.IsSetCarryOn() ){
                Team winner= PlayPoint();
                Score.AddPoint(winner);    
                DefineServer(winner);      
            }
            Score.DefineWinnerSet();
        }

        private Team PlayPoint(){
            return GetWinnerPoint(Score.GetServer(_currentTeamServicingId));
        }

        private Team GetWinnerPoint(Team server){
            var teams= Score.GetTeams();
            return server.HasWonPoint()? teams.ElementAt(0):teams.ElementAt(1);
        }

        private void DefineServer(Team newServer){
            _currentTeamServicingId= newServer.GetId();
        }
    }
}