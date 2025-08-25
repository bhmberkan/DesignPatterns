using DesignPattern.CQRS.CQRSPattern.Commands;
using DesignPattern.CQRS.DAL;

namespace DesignPattern.CQRS.CQRSPattern.Handlers
{
    public class CreateProductCommandHandler
    {
        private readonly Context _context;

        public CreateProductCommandHandler(Context context)
        {
            _context = context;
        }

        public void Handle(CreateProductCommand command)
        {
            _context.products.Add(new Product
            {
                Description = command.Description,
                Name = command.Name,
                Price = command.Price,
                Stock = command.Stock,
                Status = true,
            });
            _context.SaveChanges();
        }
    }
}
