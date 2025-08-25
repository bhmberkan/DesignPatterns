namespace DesignPattern.CQRS.CQRSPattern.Queries
{
    public class GetProductUpdateByIDQuery
    {
        public GetProductUpdateByIDQuery(int ıD)
        {
            ID = ıD;
        }

        public int ID { get; set; }
    }
}
