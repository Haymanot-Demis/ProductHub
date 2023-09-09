using MediatR;

namespace Application.Features.Product.Commands.DeleteUser;

public class DeleteProductCommand : IRequest<Unit>
{
    public int ProdId { get; set; }
}