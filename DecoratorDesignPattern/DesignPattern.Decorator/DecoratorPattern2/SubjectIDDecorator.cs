using DesignPattern.Decorator.DAL;
using System.Reflection;

namespace DesignPattern.Decorator.DecoratorPattern2
{
    public class SubjectIDDecorator : Decorator
    {
        Context context = new Context();
        private readonly ISendMessage _sendMessage;
        public SubjectIDDecorator(ISendMessage sendMessage) : base(sendMessage)
        {
            _sendMessage = sendMessage;
        }

        public void SendMessageIDSubject(Message message)
        {
            if (message.MessageSubject == "1")
            {
                message.MessageSubject = "Toplantı";
            }

            if (message.MessageSubject == "2")
            {
                message.MessageSubject = "Scrum Toplantısı";
            }


            if (message.MessageSubject == "3")
            {
                message.MessageSubject = "Haftalık Değerlendirme";
            }
            context.messages.Add(message);
            context.SaveChanges();

        }

        public override void SendMessage(Message message)
        {
            base.SendMessage(message);
            SendMessageIDSubject(message);
        }
    }
}
