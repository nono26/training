using Kata_9_Design_Pattern_Mediator.Structural;
using Kata_9_Design_Pattern_Mediator.StructuralV2;

// See https://aka.ms/new-console-template for more information
Console.WriteLine("Mediator parttern example:");

var mediator= new ConcreteMediator();
var c1= new Colleague1(mediator);
var c2= new Colleague2(mediator);

mediator.colleague1=c1;
mediator.colleague2=c2;

c1.Send("Hello world from c1");
c2.Send("Hello there!  from c2");

var MediatorV2= new ConcreteMediatorV2();
var c1_2= new Colleague1V2();
var c2_2= new Colleague2V2();

MediatorV2.Register(c1_2);
MediatorV2.Register(c2_2);

c1_2.Send("Hello world from c1_2");
c2_2.Send("Hello there!  from c2_2");
