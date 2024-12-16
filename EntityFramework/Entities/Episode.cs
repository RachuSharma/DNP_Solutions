using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Entities;

public class Episode
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; } = null!;
    public int Runtime { get; set; }
    
    public string SeasonId { get; set; } = null!; 
    
    //Constructor
    public Episode(string title, int runtime, string seasonId)
    {
        Title = title;
        Runtime = runtime;
        SeasonId = seasonId;
    }

    public Episode()
    {
        throw new NotImplementedException();
    }
}
    