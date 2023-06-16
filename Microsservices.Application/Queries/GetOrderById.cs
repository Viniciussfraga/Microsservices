using MediatR;
using Microsservices.Application.DTOs.ViewModels;

namespace Microsservices.Application.Queries
{
    public class GetOrderById : IRequest<OrderViewModel>
    {
        public Guid Id { get; private set; }

        public GetOrderById(Guid id)
        {
            Id = id;
        }
    }
}
