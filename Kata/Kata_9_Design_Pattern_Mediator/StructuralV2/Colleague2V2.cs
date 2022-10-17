namespace Kata_9_Design_Pattern_Mediator.StructuralV2
{
    public class Colleague2V2: ColleagueV2
    {

        public override void HandleNotification(string message){
            Console.WriteLine($"Colleague 2 V2 receives notification message :{message}");
        }
        
    }
}