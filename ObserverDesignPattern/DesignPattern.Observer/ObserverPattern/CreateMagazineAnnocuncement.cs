using DesignPattern.Observer.DAL;
using System;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateMagazineAnnocuncement : IObserver
    {
        private readonly IServiceProvider serviceProvider;
        Context context = new Context();

        public CreateMagazineAnnocuncement( IServiceProvider serviceProvider)
        {

            this.serviceProvider = serviceProvider;
        }

        public void CreateNewUser(AppUser appUser)
        {
            context.userProcesses.Add(new UserProcess
            {
                NameSurname = appUser.Name + " " + appUser.Surname,
                Magazine = "Bilim Dergisi",
                Content = "Bilim Dergimizin Mart Sayısı 1 Martta Evinize  Ulaştırılacaktır, Konular Jupiter Gezegeni ve Mars Olacaktır."
            });
            context.SaveChanges();
        }
    }
}
