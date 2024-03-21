namespace BookStore.WebApi.Models.Dto;

public class UpdateBookRequestDto
{
    public int CountOfPages { get; set; }
    public DateOnly PublicationDate { get; set; }
    public string Title { get; set; }
}
