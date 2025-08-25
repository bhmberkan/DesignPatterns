namespace DesignPattern.CQRS.CQRSPattern.Results
{
    public class GetProductByIDQueryResult
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

    }
}
