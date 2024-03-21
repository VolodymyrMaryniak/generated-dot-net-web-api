using BookStore.WebApi.Models.Dto;
using BookStore.WebApi.Models.OperationResults;

namespace BookStore.WebApi.Services;

public interface IBookService
{
    Task<BookResponseDto?> GetBookAsync(int id);
    Task<BookResponseDto> CreateBookAsync(CreateBookRequestDto request);
    Task<UpdateEntityResult> UpdateBookAsync(int id, UpdateBookRequestDto request);
    Task DeleteBookAsync(int id);
}
