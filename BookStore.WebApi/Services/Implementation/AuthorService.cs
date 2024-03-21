using AutoMapper;
using BookStore.WebApi.Data.Models;
using BookStore.WebApi.Data.Repositories;
using BookStore.WebApi.Models.Dto;
using BookStore.WebApi.Models.OperationResults;

namespace BookStore.WebApi.Services.Implementation;

public class AuthorService(IRepository<AuthorEntity> authorRepository, IMapper mapper) : IAuthorService
{
    public async Task<AuthorResponseDto?> GetAuthorAsync(int id)
    {
        var authorEntity = await authorRepository.FindAsync(id);
        return mapper.Map<AuthorResponseDto?>(authorEntity);
    }
    
    public async Task<AuthorResponseDto> CreateAuthorAsync(CreateAuthorRequestDto request)
    {
        var authorEntity = mapper.Map<AuthorEntity>(request);
        var createdAuthor = await authorRepository.CreateAsync(authorEntity);
        return mapper.Map<AuthorResponseDto>(createdAuthor);
    }
    
    public async Task<UpdateEntityResult> UpdateAuthorAsync(int id, UpdateAuthorRequestDto request)
    {
        var authorEntity = await authorRepository.FindAsync(id);
        if (authorEntity is null)
            return UpdateEntityResult.NotFound;
        
        mapper.Map(request, authorEntity);
        await authorRepository.UpdateAsync(authorEntity);
        return UpdateEntityResult.Success;
    }
    
    public async Task DeleteAuthorAsync(int id)
    {
        await authorRepository.DeleteAsync(id);
    }
}
