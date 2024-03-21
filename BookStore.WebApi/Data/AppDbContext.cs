using Microsoft.EntityFrameworkCore;
using BookStore.WebApi.Data.Models;

namespace BookStore.WebApi.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public required DbSet<AuthorEntity> Authors { get; init; }
    public required DbSet<BookEntity> Books { get; init; }
}
