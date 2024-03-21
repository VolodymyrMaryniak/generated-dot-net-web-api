using BookStore.WebApi.Data.Models;
using BookStore.WebApi.Data.Repositories;
using BookStore.WebApi.Data.Repositories.Implementation;
using BookStore.WebApi.Services;
using BookStore.WebApi.Services.Implementation;

namespace BookStore.WebApi.Extensions;

public static class ServiceCollectionExtensions
{
    public static void AddCustomServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IBookService, BookService>();
    }
    
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddScoped<IRepository<AuthorEntity>, Repository<AuthorEntity>>();
        services.AddScoped<IRepository<BookEntity>, Repository<BookEntity>>();
    }
    
    public static void AddAutoMapper(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(Program).Assembly);
    }
}
