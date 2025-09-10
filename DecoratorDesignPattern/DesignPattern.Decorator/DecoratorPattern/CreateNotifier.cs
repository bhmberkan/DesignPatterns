using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern
{
    public class CreateNotifier : INotifier
    {
        Context context = new Context();
        public void CreateNotify(Notifier notifier)
        {
            context.notifiers.Add(notifier);
            context.SaveChanges();
        }
    }
}
