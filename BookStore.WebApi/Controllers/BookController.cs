using Microsoft.AspNetCore.Mvc;
using BookStore.WebApi.Models.Dto;
using BookStore.WebApi.Models.OperationResults;
using BookStore.WebApi.Services;

namespace BookStore.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class BookController(IBookService service) : ControllerBase
{
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BookResponseDto), StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetBook(int id)
    {
        var book = await service.GetBookAsync(id);
        if (book == null)
            return NotFound();
        
        return Ok(book);
    }
    
    [HttpPost]
    [ProducesResponseType(typeof(BookResponseDto), StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateBook([FromBody] CreateBookRequestDto createBookRequestDto)
    {
        var createdBook = await service.CreateBookAsync(createBookRequestDto);
        
        return CreatedAtAction(nameof(GetBook), new { id = createdBook.Id }, createdBook);
    }
    
    [HttpPut("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateBook([FromRoute] int id, [FromBody] UpdateBookRequestDto updateBookRequestDto)
    {
        var result = await service.UpdateBookAsync(id, updateBookRequestDto);
        
        if (UpdateEntityResult.NotFound == result)
            return NotFound();

        return NoContent();
    }
    
    [HttpDelete("{id}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    public async Task<IActionResult> DeleteBook([FromRoute] int id)
    {
        await service.DeleteBookAsync(id);
        
        return NoContent();
    }
}
