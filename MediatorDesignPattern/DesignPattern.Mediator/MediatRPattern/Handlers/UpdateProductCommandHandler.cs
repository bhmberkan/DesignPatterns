using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatRPattern.Commands;
using MediatR;

namespace DesignPattern.Mediator.MediatRPattern.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly Context _context;

        public UpdateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var values = _context.products.Find(request.ProductID);
            values.ProductName= request.ProductName;
            values.ProductPrice= request.ProductPrice;
            values.ProductStock= request.ProductStock;
            values.ProductCategory= request.ProductCategory;
            values.ProductStockType= request.ProductStockType;
            await _context.SaveChangesAsync();
        }
    }
}
