using Application.DTO.Category;
using Application.Features.Category.Commands.CreateCategory;
using Application.Features.Category.Commands.DeleteCategory;
using Application.Features.Category.Commands.UpdateCategory;
using Application.Features.Category.Queries.GetCategoryById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryControllers : ControllerBase
{
    private readonly IMediator _mediator;

    public CategoryControllers(IMediator mediator)
    {
        _mediator = mediator;
    }
    
    [HttpGet("{id:int}")]
    public async Task<IActionResult> Get(int id)
    {
        var query = new GetCategoryByIdQuery() { Id = id };
        var category = await _mediator.Send(query);
        return Ok(category);
    }
    
    [HttpPost("CreateCategory")]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto categoryDto)
    {
        var command = new CreateCategoryCommand() { CreateCategoryDto = categoryDto };
        var category = await _mediator.Send(command);
        return CreatedAtAction(nameof(Get),new{Id =category.Id }, category );
    }
    
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update(int id, CreateCategoryDto categoryDto)
    {
        var command = new UpdateCategoryCommand() {Id = id, CategoryDto = categoryDto };
        var category = await _mediator.Send(command);
        return Ok(category);
    }
    
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete(int id)
    {
        var command = new DeleteCategoryCommand() {Id = id};
        var category = await _mediator.Send(command);
        return NoContent();
    }
}