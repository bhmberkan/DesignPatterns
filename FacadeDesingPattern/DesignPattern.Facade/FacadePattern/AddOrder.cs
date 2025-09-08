using DesignPattern.Facade.DAL;

namespace DesignPattern.Facade.FacadePattern
{
    public class AddOrder
    {
        Context context = new Context();
        
        public void AddNewOrder(Order order)
        {
            order.OrderDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            context.orders.Add(order);
            context.SaveChanges();
        }
    }
}
