using DesignPattern.Mediator.MediatRPattern.Results;
using MediatR;

namespace DesignPattern.Mediator.MediatRPattern.Queries
{
    public class GetProductUpdateByIDQuery : IRequest<UpdateProductByIDQueryResult>
    {
        public GetProductUpdateByIDQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }

       
    }
}
