using BookStore.WebApi.Models.Dto;
using BookStore.WebApi.Models.OperationResults;

namespace BookStore.WebApi.Services;

public interface IAuthorService
{
    Task<AuthorResponseDto?> GetAuthorAsync(int id);
    Task<AuthorResponseDto> CreateAuthorAsync(CreateAuthorRequestDto request);
    Task<UpdateEntityResult> UpdateAuthorAsync(int id, UpdateAuthorRequestDto request);
    Task DeleteAuthorAsync(int id);
}
