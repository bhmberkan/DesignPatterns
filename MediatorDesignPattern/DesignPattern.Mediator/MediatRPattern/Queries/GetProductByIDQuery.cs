using DesignPattern.Mediator.MediatRPattern.Results;
using MediatR;

namespace DesignPattern.Mediator.MediatRPattern.Queries
{
    public class GetProductByIDQuery : IRequest<GetProductByIDQueryResult>
    {
        public GetProductByIDQuery(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
    
}
