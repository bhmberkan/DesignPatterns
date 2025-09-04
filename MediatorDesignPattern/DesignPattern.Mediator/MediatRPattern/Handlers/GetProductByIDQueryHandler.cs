using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatRPattern.Queries;
using DesignPattern.Mediator.MediatRPattern.Results;
using MediatR;
using System.Diagnostics;

namespace DesignPattern.Mediator.MediatRPattern.Handlers
{
    public class GetProductByIDQueryHandler : IRequestHandler<GetProductByIDQuery, GetProductByIDQueryResult>
    {
        private readonly Context _context;

        public GetProductByIDQueryHandler(Context context)
        {
            _context = context;
        }

        public async Task<GetProductByIDQueryResult> Handle(GetProductByIDQuery request, CancellationToken cancellationToken)
        {
            var values = await _context.products.FindAsync(request.Id);
            return new GetProductByIDQueryResult
            {
                ProductID=values.ProductID,
                ProductName = values.ProductName,
                ProductStock = values.ProductStock
            };
        }
    }
}
