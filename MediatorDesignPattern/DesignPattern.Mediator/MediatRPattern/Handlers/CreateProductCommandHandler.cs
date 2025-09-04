using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatRPattern.Commands;
using MediatR;

namespace DesignPattern.Mediator.MediatRPattern.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand>
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            _context.products.Add(new Product
            {
                ProductName = request.ProductName,
                ProductCategory = request.ProductCategory,
                ProductPrice = request.ProductPrice,
                ProductStock = request.ProductStock,
                ProductStockType = request.ProductStockType
            });
            await _context.SaveChangesAsync();
        }
    }
}
