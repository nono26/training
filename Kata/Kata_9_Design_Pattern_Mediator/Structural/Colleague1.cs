using System;

namespace Kata_9_Design_Pattern_Mediator.Structural
{
    public class Colleague1: Colleague
    {
        public Colleague1(Mediator mediator): base(mediator){}

        public override void HandleNotification(string message){
            Console.WriteLine($"Colleague 1 receives notification message :{message}");
        }
        
    }
}