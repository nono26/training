namespace Kata_9_Design_Pattern_Mediator.Structural
{
    public abstract class Mediator
    {
        public abstract void Send(string message,Colleague colleague);
    }
}