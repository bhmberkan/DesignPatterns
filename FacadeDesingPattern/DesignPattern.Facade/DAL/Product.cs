namespace DesignPattern.Facade.DAL
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }

        public List<OrderDetail> orderDetails { get; set; }
    }
}
