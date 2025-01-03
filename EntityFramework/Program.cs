// See https://aka.ms/new-console-template for more information

using EntityFramework;
using EntityFramework.Entities;
using AppContext = EntityFramework.AppContext;

Console.WriteLine("Hello, Entity Framework Core!");


//add dummy data from AppContext
using (var ctx = new AppContext())
{
    var dataAccess = new DataAccess(ctx);
    ctx.Database.EnsureCreated();

    var show1 = new Show("The Simpsons", 1989, "Comedy");
    var episode1 = new Episode("Simpsons Roasting on an Open Fire", 30, "S01");
    var episode2 = new Episode("Bart the Genius", 30, "S01");
    show1.Episodes.AddRange(new[] { episode1, episode2 });

    var show2 = new Show("Breaking Bad", 2008, "Drama");
    var episode3 = new Episode("Pilot", 58, "S01");
    var episode4 = new Episode("Cat's in the Bag...", 48, "S01");
    show2.Episodes.AddRange(new[] { episode3, episode4 });
    
    await ctx.Shows.AddAsync(show1);
    await ctx.Shows.AddAsync(show2);
    await ctx.SaveChangesAsync();
    
    
    
    Console.WriteLine("Data added! " + show1.ShowId + show1.Title + show2.ShowId + show2.Title);
  
    
    
    
    
    
    

    Console.WriteLine("Data added! " + show1.ShowId + show1.Title + show2.ShowId + show2.Title);
    Console.WriteLine(dataAccess.GetAll());
    Console.ReadLine();
    
}