namespace WebApi.Entities;

public class UserStory
{
     public required int Id { get; set; }
     public required string Description { get; set; }
     public required string Estimate { get; set; }
}