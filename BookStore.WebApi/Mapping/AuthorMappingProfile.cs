using AutoMapper;
using BookStore.WebApi.Data.Models;
using BookStore.WebApi.Models.Dto;

namespace BookStore.WebApi.Mapping;

public class AuthorMappingProfile : Profile
{
    public AuthorMappingProfile()
    {
        CreateMap<CreateAuthorRequestDto, AuthorEntity>();
        CreateMap<UpdateAuthorRequestDto, AuthorEntity>();
        CreateMap<AuthorEntity, AuthorResponseDto>();
    }
}
