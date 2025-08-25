using DesignPattern.CQRS.CQRSPattern.Queries;
using DesignPattern.CQRS.CQRSPattern.Results;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class GetProductUpdateByIDQueryHandler
    {
        private readonly Context _context;

        public GetProductUpdateByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public GetProductUpdateQueryResult Handle(GetProductUpdateByIDQuery query)
        {
            var values = _context.products.Find(query.ID);
            return new GetProductUpdateQueryResult
            {
                ProductID = query.ID,
                Description = values.Description,
                Name = values.Name,
                Price = values.Price,
                Stock = values.Stock,
                Status = values.Status
            };
        }
    }
}
