using DesignPattern.Decorator.DAL;
using DesignPattern.Decorator.DecoratorPattern2;
using Microsoft.AspNetCore.Mvc;

namespace DesignPattern.Decorator.Controllers
{
    public class DefaultController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Message message)
        {
            CreateNewMessage createNewMessage = new CreateNewMessage();
            createNewMessage.SendMessage(message);
            return View();
        }
        [HttpGet]
        public IActionResult Index2()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index2(Message message)
        {
            CreateNewMessage createNewMessage = new CreateNewMessage();
            EncryptoBySubjectDecorator encryptoBySubjectDecorator = new EncryptoBySubjectDecorator(createNewMessage);
            encryptoBySubjectDecorator.SendMessageByEncryptoSubject(message);
            return View();
        }

        [HttpGet]
        public IActionResult Index3()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index3(Message message)
        {
            CreateNewMessage createNewMessage = new CreateNewMessage();
            SubjectIDDecorator subjectIDDecorator = new SubjectIDDecorator(createNewMessage);
            subjectIDDecorator.SendMessageIDSubject(message);
            return View();
        }

       /* public IActionResult Index()
        {
            Message message = new Message();
            message.MessageContent = "Bu bir Content mesajıdır.";
            message.MessageSender = "Admin  İK.";
            message.MessageReceiver = "Herkes.";
            message.MessageSubject = "Deneme Yapıyoruz.";
            CreateNewMessage createNewMessage = new CreateNewMessage();
            createNewMessage.SendMessage(message);
            return View();
        }

        public IActionResult Index2()
        {
            Message message = new Message();
            message.MessageContent = "Bu bir Subjext Şifreli  Mesajdır.";
            message.MessageSender = "Team Lead.";
            message.MessageReceiver = "Herkes.";
            message.MessageSubject = "Merhaba.";
            CreateNewMessage createNewMessage = new CreateNewMessage();
            EncryptoBySubjectDecorator encryptoBySubjectDecorator = new EncryptoBySubjectDecorator(createNewMessage);
            encryptoBySubjectDecorator.SendMessageByEncryptoSubject(message);
            return View();
        }*/
    }
}
