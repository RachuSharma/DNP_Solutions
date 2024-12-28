using BlazorAppA.Entities;

namespace BlazorAppA.Service;

public interface IYearBookService
{
    public Task RegisterYearBookEntry(YearBookEntry yearBookEntry);
    public Task<List<YearBookEntry>> GetYearBookEntries();
}