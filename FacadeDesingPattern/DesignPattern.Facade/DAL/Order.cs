namespace DesignPattern.Facade.DAL
{
    public class Order
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public Customer customer { get; set; }
        public DateTime OrderDate { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
