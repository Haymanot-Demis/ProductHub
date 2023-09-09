using Application.Contracts.Persistence;
using Application.DTO.Category;
using Application.Exceptions;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands.UpdateCategory;

public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, CategoryResponseDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public UpdateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }
    
    public async Task<CategoryResponseDto> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
    {
        var validator = new UpdateCategoryCommandValidator();
        var validationResult = validator.Validate(request);
        if (!validationResult.IsValid)
        {
            throw new ValidationException(validationResult.Errors);
        }
        
        var categoryToUpdate = await _categoryRepository.GetByIdAsync(request.Id);
        
        if (categoryToUpdate == null)
        {
            throw new NotFoundException($"Category with id {request.Id} not found");
        }
        
        var updatedCategory = _mapper.Map(request.CategoryDto, categoryToUpdate);
        await _categoryRepository.UpdateAsync(updatedCategory);
        return _mapper.Map<CategoryResponseDto>(updatedCategory);
    }
}