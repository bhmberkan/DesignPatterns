using DesignPattern.Mediator.DAL;
using DesignPattern.Mediator.MediatRPattern.Commands;
using MediatR;

namespace DesignPattern.Mediator.MediatRPattern.Handlers
{
    public class RemoveProductCommandHandler : IRequestHandler<RemoveProductCommand>
    {
        private readonly Context  _context;

        public RemoveProductCommandHandler(Context context)
        {
            _context = context;
        }

        public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
        {
            var values = _context.products.Find(request.Id);
            _context.products.Remove(values);
            await _context.SaveChangesAsync();
        }
    }
}
