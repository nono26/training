namespace Kata_9_Design_Pattern_Mediator.StructuralV2
{
    public abstract class ColleagueV2
    {
        protected MediatorV2 mediator;

        internal void SetMediator(MediatorV2 mediator){
            this.mediator= mediator;
        }

        public virtual void Send(string message ){
            this.mediator.Send(message, this);
        }

        public abstract void HandleNotification(string message);
    }
}