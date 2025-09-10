using DesignPattern.Decorator.DAL;
using System;
using System.Reflection;

namespace DesignPattern.Decorator.DecoratorPattern2
{
    public class EncryptoBySubjectDecorator : Decorator
    {
        Context context = new Context();
        private readonly ISendMessage _sendMessage;

        public EncryptoBySubjectDecorator(ISendMessage sendMessage) : base(sendMessage)
        {
            _sendMessage = sendMessage;
        }

        public void SendMessageByEncryptoSubject(Message message)
        {
            //message.MessageSender = "İnsan Kaynakları";
            //message.MessageReceiver = "Yazılım Ekibi";
            //message.MessageContent = "Saat 12:00'da Toplantı Var";
            //message.MessageSubject = "Toplantı";

            string data = "";
            data = message.MessageSubject;
            char[] chars = data.ToCharArray();
            foreach (var item in chars)
            {
                message.MessageSubject += Convert.ToChar(item + 3).ToString();
            }

            context.messages.Add(message);
            context.SaveChanges();
        }

        public override void SendMessage(Message message)
        {
            base.SendMessage(message);
            SendMessageByEncryptoSubject(message);
        }
    }
}
