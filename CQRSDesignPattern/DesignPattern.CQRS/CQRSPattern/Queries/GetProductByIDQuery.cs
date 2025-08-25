namespace DesignPattern.CQRS.CQRSPattern.Queries
{
    public class GetProductByIDQuery
    {
        public GetProductByIDQuery(int ıD)
        {
            ID = ıD;
        }

        public int ID { get; set; }

    }
}
