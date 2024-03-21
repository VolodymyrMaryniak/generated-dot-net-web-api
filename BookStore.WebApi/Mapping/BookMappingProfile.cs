using AutoMapper;
using BookStore.WebApi.Data.Models;
using BookStore.WebApi.Models.Dto;

namespace BookStore.WebApi.Mapping;

public class BookMappingProfile : Profile
{
    public BookMappingProfile()
    {
        CreateMap<CreateBookRequestDto, BookEntity>();
        CreateMap<UpdateBookRequestDto, BookEntity>();
        CreateMap<BookEntity, BookResponseDto>();
    }
}
