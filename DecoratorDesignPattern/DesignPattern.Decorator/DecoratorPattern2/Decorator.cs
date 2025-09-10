using DesignPattern.Decorator.DAL;

namespace DesignPattern.Decorator.DecoratorPattern2
{
    public class Decorator : ISendMessage
    {
        private readonly ISendMessage _sendMessage;

        public Decorator(ISendMessage sendMessage)
        {
            _sendMessage = sendMessage;
        }

        virtual public void SendMessage(Message message) //  ezeceğim.
        {
            message.MessageReceiver = "EveryBody";
            message.MessageSender = "Admin";
            message.MessageContent = "Merhaba Bu bir Toplantı Mesajıdır.";
            message.MessageSubject = "Toplantı";
            _sendMessage.SendMessage(message);
        }
    }
}
