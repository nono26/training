using Serilog;

namespace VolleyBall.Core
{
    public class Score
    {
        private const int MaxSetPerMatch= 3;
        private List<Set> _sets= new List<Set>();
        private IEnumerable<Team> _teams;

        public Score(IEnumerable<Team> teams){
            _teams= teams;
        }

        public void AddPoint(Team Team){            
            _sets.Last().AddPoint(Team);
            DisplayScore();
        }

        public void DefineWinnerSet(){
            _sets.Last().DefineWinner();
        }

        public void NewSet(){
            var server= _teams.First().GetId();
            if(_sets.Count()>0)
                server=GetNewServer(_sets.Last().GetServer());
            _sets.Add(new Set(server,_teams,_sets.Count()==4));
        }

        public bool IsMatchNotFinished(){
            bool MatchNotFinished= true;
            if(_sets.Count()>0){
                foreach(Team team in _teams){
                    MatchNotFinished = MatchNotFinished && _sets.Where(set=> set.GetWinner()==team.GetId()).Count() < MaxSetPerMatch;
                }
            }
            return MatchNotFinished;
        }

        public bool IsSetCarryOn(){
            return !_sets.Last().IsSetFinished();
        }
        
        public List<Set> GetSets(){
            return _sets;
        }

        public Team GetServer(string serverId){
            return _teams.Single(t=> t.GetId() == serverId);
        }

        public IEnumerable<Team> GetTeams(){
            return _teams;
        }

        private string GetNewServer(string currentServerId){
            return _teams.ElementAt(1).GetId();
        }
        private void DisplayScore(){    
            string Dashboard= string.Empty;
            foreach(Set item in _sets){
                Dashboard = Dashboard+ item.GetScore() +" ";
            }     
            Log.Information($"{Dashboard}");
        }  
    }
}