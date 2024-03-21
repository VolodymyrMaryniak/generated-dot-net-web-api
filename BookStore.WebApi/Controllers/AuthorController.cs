using Microsoft.AspNetCore.Mvc;
using BookStore.WebApi.Models.Dto;
using BookStore.WebApi.Models.OperationResults;
using BookStore.WebApi.Services;

namespace BookStore.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthorController(IAuthorService service) : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(AuthorResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAuthor(int id)
    {
        var author = await service.GetAuthorAsync(id);
        if (author == null)
            return NotFound();
        
        return Ok(author);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(AuthorResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateAuthor([FromBody] CreateAuthorRequestDto createAuthorRequestDto)
    {
        var createdAuthor = await service.CreateAuthorAsync(createAuthorRequestDto);
        
        return CreatedAtAction(nameof(GetAuthor), new { id = createdAuthor.Id }, createdAuthor);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateAuthor([FromRoute] int id, [FromBody] UpdateAuthorRequestDto updateAuthorRequestDto)
    {
        var result = await service.UpdateAuthorAsync(id, updateAuthorRequestDto);
        
        if (UpdateEntityResult.NotFound == result)
            return NotFound();

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteAuthor([FromRoute] int id)
    {
        await service.DeleteAuthorAsync(id);
        
        return NoContent();
    }
}
