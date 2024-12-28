namespace BlazorAppA.Entities;

public class YearBookEntry
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Pronouns { get; set; }
    public string FunFact { get; set; }
    public string ImageUrl { get; set; }
    public int Year { get; set; }

    public YearBookEntry(int id, string name, string pronouns, string funFact, string imageUrl, int year)
    {
        Id = id;
        Name = name;
        Pronouns = pronouns;
        FunFact = funFact;
        ImageUrl = imageUrl;
    }

    public YearBookEntry()
    {
        
    }
}