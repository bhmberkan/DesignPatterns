using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatRPattern.Queries;
using DesignPattern.Mediator.MediatRPattern.Results;
using MediatR;

namespace DesignPattern.Mediator.MediatRPattern.Handlers
{
    public class GetProductUpdateByIDQueryHandler : IRequestHandler<GetProductUpdateByIDQuery, UpdateProductByIDQueryResult>
    {
        private readonly Context _context;

        public GetProductUpdateByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<UpdateProductByIDQueryResult> Handle(GetProductUpdateByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.products.FindAsync(request.Id);
            return new UpdateProductByIDQueryResult
            {
                ProductID=values.ProductID,
                ProductCategory=values.ProductCategory,
                ProductName=values.ProductName,
                ProductPrice=values.ProductPrice,
                ProductStock=values.ProductStock,
                ProductStockType=values.ProductStockType
            };
        }
    }
}
