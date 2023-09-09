using Application.Contracts.Persistence;
using Application.Exceptions;
using MediatR;

namespace Application.Features.Category.Commands.DeleteCategory;

public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, Unit>
{
    private readonly ICategoryRepository _categoryRepository;

    public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
    {
        _categoryRepository = categoryRepository;
    }

    public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
    {
        var category = await _categoryRepository.GetByIdAsync(request.Id);
        if (category == null)
        {
            throw new NotFoundException($"Category with id {request.Id} not found");
        }
        
        await _categoryRepository.DeleteAsync(category);
        return Unit.Value;
    }
}