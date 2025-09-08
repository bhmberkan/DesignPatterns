namespace DesignPattern.Facade.DAL
{
    public class AddOrderDetail
    {
        Context context = new Context();
        public void AddNewOrderDetail(OrderDetail orderDetail)
        {
            context.orderDetails.Add(orderDetail);
            context.SaveChanges();
        }
    }
}
