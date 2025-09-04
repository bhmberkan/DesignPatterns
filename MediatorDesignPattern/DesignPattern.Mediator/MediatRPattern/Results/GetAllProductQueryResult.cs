namespace DesignPattern.Mediator.MediatRPattern.Results
{
    public class GetAllProductQueryResult
    {

        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int ProductStock { get; set; }
        public string ProductStockType { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductCategory { get; set; }
    }
}
