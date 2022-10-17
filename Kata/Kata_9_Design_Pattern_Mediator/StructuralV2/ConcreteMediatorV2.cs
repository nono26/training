namespace Kata_9_Design_Pattern_Mediator.StructuralV2
{
    public class ConcreteMediatorV2:MediatorV2
    {
        private List<ColleagueV2> colleagues= new List<ColleagueV2>();

        public void Register(ColleagueV2 colleague){

            colleague.SetMediator(this);
            this.colleagues.Add(colleague);
        }
        public override void Send(string message, ColleagueV2 colleague)
        {
            this.colleagues.Where(c => c!= colleague).ToList().ForEach(c=> c.HandleNotification(message));
        }
    }
}