using EntityFramework.Entities;
using Microsoft.EntityFrameworkCore;

namespace EntityFramework;

public class DataAccess
{
    private readonly AppContext Context;

    public DataAccess(AppContext context)
    {
        Context = context;
    }

    public async Task<Show> createShowAsync(Show show)
    {
        await Context.Shows.AddAsync(show);
        await Context.SaveChangesAsync();
        return show;
    }

    public async Task<Episode> AddEpisodeToShowAsync(int showIsd, Episode episode)
    {
        var show = await Context.Shows.FindAsync(showIsd);
        show.Episodes.Add(episode);
        await Context.SaveChangesAsync();
        return episode;
    }

    public async Task<List<Show>> GetAll(string genre = null, int year = 0)
    {
        var query = Context.Shows.AsQueryable();
        if (genre != null)
        {
            query = query.Where(s => s.Genre == genre);
        }

        {
            query = query.Where(s => s.Year == year);
        }
        return await query.ToListAsync();
    }

    public async Task<List<Show>> GetAllShowsAsync(string genreFilter = null, int? yearFilter = null)
    {
        var query = Context.Shows.AsQueryable();

        if (!string.IsNullOrEmpty(genreFilter))
            query = query.Where(s => s.Genre == genreFilter);

        if (yearFilter.HasValue)
            query = query.Where(s => s.Year == yearFilter);

        return await query.ToListAsync();
    }

    public async Task<List<Show>> GetAllShowsOrderedByRuntimeAsync()
    {
        return await Context.Shows
            .OrderByDescending(show => show.Episodes.Sum(ep => ep.Runtime))
            .ToListAsync();
    }
}