namespace VolleyBall.Core
{
    public class Team
    {
        private string _id{get;set;}
        private int _prob{get;set;}

        public Team(string id, int prob){
            _id= id;
            _prob= prob;
        }
        public string GetId(){
            return _id;
        }

        public bool HasWonPoint(){
            return _prob> new Random().Next(100);
        }
    }
}