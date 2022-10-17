namespace Kata_9_Design_Pattern_Mediator.Structural
{
    public class Colleague2: Colleague
    {
        public Colleague2(Mediator mediator): base(mediator){}

        public override void HandleNotification(string message){
            Console.WriteLine($"Colleague 2 receives notification message :{message}");
        }
        
    }
}