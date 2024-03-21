using AutoMapper;
using BookStore.WebApi.Data.Models;
using BookStore.WebApi.Data.Repositories;
using BookStore.WebApi.Models.Dto;
using BookStore.WebApi.Models.OperationResults;

namespace BookStore.WebApi.Services.Implementation;

public class BookService(IRepository<BookEntity> bookRepository, IMapper mapper) : IBookService
{
    public async Task<BookResponseDto?> GetBookAsync(int id)
    {
        var bookEntity = await bookRepository.GetByIdAsync(id);
        return mapper.Map<BookResponseDto?>(bookEntity);
    }
    
    public async Task<BookResponseDto> CreateBookAsync(CreateBookRequestDto request)
    {
        var bookEntity = mapper.Map<BookEntity>(request);
        var createdBook = await bookRepository.CreateAsync(bookEntity);
        return mapper.Map<BookResponseDto>(createdBook);
    }
    
    public async Task<UpdateEntityResult> UpdateBookAsync(int id, UpdateBookRequestDto request)
    {
        var bookEntity = await bookRepository.GetByIdAsync(id);
        if (bookEntity is null)
            return UpdateEntityResult.NotFound;
        
        mapper.Map(request, bookEntity);
        await bookRepository.UpdateAsync(bookEntity);
        return UpdateEntityResult.Success;
    }
    
    public async Task DeleteBookAsync(int id)
    {
        await bookRepository.DeleteAsync(id);
    }
}
