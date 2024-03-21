namespace BookStore.WebApi.Models.Dto;

public class CreateBookRequestDto
{
    public int CountOfPages { get; set; }
    public DateOnly PublicationDate { get; set; }
    public string Title { get; set; }
}
