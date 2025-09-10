using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern
{
    public class Decorator : INotifier
    {
        private readonly INotifier _notifier;

        public Decorator(INotifier notifier)
        {
            _notifier = notifier;
        }

        virtual public void CreateNotify(Notifier notifier) // override edebilmek için(ezebilmek için) virtual parametresi ekledim.
        { // yani aşağıdaki kismi uygulamamın istediğim yerine değiştirebileceğim.

            notifier.NotifierCreator = "Admin";
            notifier.NotifierSubject = "Toplantı";
            notifier.NotifierType = "Public";
            notifier.NotifierChannel = "Whatsapp";
            _notifier.CreateNotify(notifier);
        }
    }
}
