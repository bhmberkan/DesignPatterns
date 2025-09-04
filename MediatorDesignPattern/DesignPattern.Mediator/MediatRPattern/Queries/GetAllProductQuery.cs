using DesignPattern.Mediator.MediatRPattern.Results;
using MediatR;

namespace DesignPattern.Mediator.MediatRPattern.Queries
{
    public class GetAllProductQuery : IRequest<List<GetAllProductQueryResult>>
    {

    }
}
