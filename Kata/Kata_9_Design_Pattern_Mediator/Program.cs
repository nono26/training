using Kata_9_Design_Pattern_Mediator.Structural;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Mediator parttern example:");

var mediator= new ConcreteMediator();
var c1= new Colleague1(mediator);
var c2= new Colleague2(mediator);

mediator.colleague1=c1;
mediator.colleague2=c2;

c1.Send("Hello world from c1");
c2.Send("Hello there!  from c2");
