namespace DesignPattern.Facade.DAL
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int? ProductID { get; set; }
        public Product product { get; set; }

        public int? CustomerID { get; set; }
        public Customer customer { get; set; }

        public int? OrderID { get; set; }
        public Order order { get; set; }

        public int ProductCount { get; set; }
        public decimal ProductPrice { get; set; }
        public decimal ProductTotalPrice { get; set; }

     
    }
}
