using System.ComponentModel.DataAnnotations;

namespace EntityFramework.Entities;

public class Show
{
    [Key] public int Id { get; set; }
    public string Title { get; set; } = null!;
    public short Year { get; set; }
    public string Genre { get; set; } = null!;
    public List<Episode> Episodes { get; set; } = [];

    //Constructor
    public Show(string title, short year, string genre)
    {
        Title = title;
        Year = year;
        Genre = genre;
        Episodes = new List<Episode>();
    }

    public Show()
    {
        throw new NotImplementedException();
    }
}