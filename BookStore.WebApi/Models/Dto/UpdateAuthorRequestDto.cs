namespace BookStore.WebApi.Models.Dto;

public class UpdateAuthorRequestDto
{
    public DateOnly Birthday { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
}
