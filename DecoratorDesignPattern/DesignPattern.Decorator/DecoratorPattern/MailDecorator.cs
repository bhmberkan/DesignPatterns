using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern
{
    public class MailDecorator : Decorator
    {
        Context context = new Context();    
        private readonly INotifier _notifier;

        public MailDecorator(INotifier notifier) : base(notifier)
        {
            _notifier = notifier;
        }

        public void SendMailNotifiy(Notifier notifier)
        {
            notifier.NotifierSubject = "Günlük Sabah Toplantısı";
            notifier.NotifierCreator = "Scrum Master";
            notifier.NotifierChannel = "GMail-Outlook";
            notifier.NotifierType = "Private Team";

            context.notifiers.Add(notifier);
            context.SaveChanges();
        }

        public override void CreateNotify(Notifier notifier) // virtual ettiğimiz alanı burada eziyoruz.
        {
            base.CreateNotify(notifier);
            SendMailNotifiy(notifier);
        }
    }
}
