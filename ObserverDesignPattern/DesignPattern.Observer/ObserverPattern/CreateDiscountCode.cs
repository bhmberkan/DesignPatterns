using DesignPattern.Observer.DAL;
using System;

namespace DesignPattern.Observer.ObserverPattern
{
    public class CreateDiscountCode : IObserver
    {
        private readonly IServiceProvider _serviceProvider;
        Context context = new Context();

        public CreateDiscountCode( IServiceProvider serviceProvider)
        {
    
            _serviceProvider = serviceProvider;
        }

        public void CreateNewUser(AppUser appUser)
        {
            context.discounts.Add(new Discount
            {
                DiscountCode = "DERGIMART",
                DiscountAmount = 35,
                DiscountCodeStatus = true
            });
            context.SaveChanges();
        }
    }
}
