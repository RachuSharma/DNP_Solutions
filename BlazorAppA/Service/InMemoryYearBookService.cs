using BlazorAppA.Entities;

namespace BlazorAppA.Service;

public class InMemoryYearBookService : IYearBookService
{
    private readonly List<YearBookEntry> _yearBookEntries;

    public InMemoryYearBookService()
    {
        _yearBookEntries = new List<YearBookEntry>
        {
            new YearBookEntry
            {
                Id = 1,
                Name = "Rachana Sharma",
                Pronouns = "She/Her",
                FunFact = "Like to play the guitar",
                ImageUrl = "https://via.placeholder.com/150",
                Year = 2020
            },
            new YearBookEntry
            {
                Id = 2,
                Name = "Prabina Bhandari",
                Pronouns = "She/Her",
                FunFact = "Like to play the piano",
                ImageUrl = "https://via.placeholder.com/150",
                Year = 2021
            },
            new YearBookEntry
            {
                Id = 3,
                Name = "Himal Sharma",
                Pronouns = "They/Them",
                FunFact = "Like to play the drums",
                ImageUrl = "https://via.placeholder.com/150",
                Year = 2022
            },
            new YearBookEntry
            {
                Id = 4,
                Name = "Rajip Shrestha",
                Pronouns = "He/Him",
                FunFact = "Like to play the guitar",
                ImageUrl = "https://via.placeholder.com/150",
                Year = 2023
            },
            new YearBookEntry
            {
                Id = 5,
                Name = "Ramesh Bhatta",
                Pronouns = "He/Him",
                FunFact = "Like to play the guitar",
                ImageUrl = "https://via.placeholder.com/150",
                Year = 2024
            }
        };
    }

    public Task RegisterYearBookEntry(YearBookEntry yearBookEntry)
    {
        yearBookEntry.Id = _yearBookEntries.Count + 1;
        _yearBookEntries.Add(yearBookEntry);
        return Task.CompletedTask;
    }

    public Task<List<YearBookEntry>> GetYearBookEntries()
    {
        return Task.FromResult(_yearBookEntries);
    }
}