using System;
using System.Text;

namespace VolleyBall.Core
{
    public class Set
    {
        private Dictionary<string,int> Point{get;set;}
        private bool _isFifthSet{get;set;}   
        private string _winner{get;set;}  
        private string _server{get;set;}   
        private const int MaxPointPerSet= 25;
        private const int MaxPointFifthSet= 15;

        public Set(string server , IEnumerable<Team> teams,bool isFifthSet = false){
            _isFifthSet= isFifthSet;
            _server=server;
            Point= new Dictionary<string, int>();
            foreach(Team team in teams){
                Point.Add(team.GetId(),0);
            }
        }

        public void AddPoint(Team winnerPoint){
            if(Point.ContainsKey(winnerPoint.GetId()))
                Point[winnerPoint.GetId()] ++;
        }
        
        public bool IsSetFinished(){
            int MaxValue= _isFifthSet ? MaxPointFifthSet: MaxPointPerSet;
            bool hasReachedMinMaxPoint=false;
            foreach(int point in Point.Values)
                if(hasReachedMinMaxPoint= hasReachedMinMaxPoint || point >= MaxValue)
                break;
            return hasReachedMinMaxPoint && TwoPointConditions();        
        }

        public void DefineWinner(){
                _winner= Point.Aggregate((x,y) => x.Value> y.Value? x: y).Key;
        }

        private bool TwoPointConditions(){
            var sortedPoint= from entry in Point orderby entry.Value descending select entry.Value;
            return Math.Abs(sortedPoint.ElementAt(0)- sortedPoint.ElementAt(1)) >=2;            
        }

        public string GetWinner(){
            return _winner;
        }

        public string GetScore(){
            StringBuilder score= new StringBuilder();
            foreach(KeyValuePair<string,int>  team in Point)
                score.Append($"[{team.Key}]:{team.Value} - ");
            score.Remove(score.Length-2,2);
            return score.ToString();
        }

        public string GetServer(){
            return _server;
        }
    }
}