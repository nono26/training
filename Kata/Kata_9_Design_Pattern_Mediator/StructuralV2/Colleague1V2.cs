using System;

namespace Kata_9_Design_Pattern_Mediator.StructuralV2
{
    public class Colleague1V2: ColleagueV2
    {

        public override void HandleNotification(string message){
            Console.WriteLine($"Colleague 1 V2 receives notification message :{message}");
        }
        
    }
}