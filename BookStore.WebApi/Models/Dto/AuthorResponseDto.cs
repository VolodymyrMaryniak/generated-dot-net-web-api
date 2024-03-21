namespace BookStore.WebApi.Models.Dto;

public class AuthorResponseDto
{
    public DateOnly Birthday { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Id { get; set; }
}
