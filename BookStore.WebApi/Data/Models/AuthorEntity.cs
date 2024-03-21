using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApi.Data.Models;

public class AuthorEntity : IEntity
{
    [Key]
    public int Id { get; set; }
    
    public DateOnly Birthday { get; set; }

    [MaxLength(1000)] // TODO: Update the MaxLength value with what you need
    public string FirstName { get; set; }

    [MaxLength(1000)] // TODO: Update the MaxLength value with what you need
    public string LastName { get; set; }

}
