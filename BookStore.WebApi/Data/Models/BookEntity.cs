using System.ComponentModel.DataAnnotations;

namespace BookStore.WebApi.Data.Models;

public class BookEntity : IEntity
{
    [Key]
    public int Id { get; set; }
    
    public int CountOfPages { get; set; }

    public DateOnly PublicationDate { get; set; }

    [MaxLength(1000)] // TODO: Update the MaxLength value with what you need
    public string Title { get; set; }

}
