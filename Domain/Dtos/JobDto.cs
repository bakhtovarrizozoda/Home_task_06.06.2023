namespace Domain.Dtos;

public class JobDto
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public int CategoryId { get; set; }
    public DateTime ClousingDate { get; set; }
}
