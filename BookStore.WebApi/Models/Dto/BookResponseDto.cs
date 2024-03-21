namespace BookStore.WebApi.Models.Dto;

public class BookResponseDto
{
    public int CountOfPages { get; set; }
    public DateOnly PublicationDate { get; set; }
    public string Title { get; set; }
    public int Id { get; set; }
}
