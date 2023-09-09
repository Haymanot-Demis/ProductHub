using Application.Contracts.Persistence;
using Application.DTO.Category;
using AutoMapper;
using Domain.Entites;
using FluentValidation;
using MediatR;

namespace Application.Features.Category.Commands.CreateCategory;

public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CategoryResponseDto>
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    
    public CreateCategoryCommandHandler(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }
    public async Task<CategoryResponseDto> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
    {
        // validator
        var validator = new CreateCategoryCommandValidator();
        var validationResult = await validator.ValidateAsync(request, cancellationToken);
        
        // validating the incoming request
        if (validationResult.Errors.Count > 0)
        {
            throw new ValidationException(validationResult.Errors);
        }
       
        // mapping the incoming request to the user entity
        var category = _mapper.Map<CategoryEntity>(request.CreateCategoryDto);
        
        // adding the user to the database
        var newCategory = await _categoryRepository.CreateAsync(category);
        return _mapper.Map<CategoryResponseDto>(newCategory);
    }
}