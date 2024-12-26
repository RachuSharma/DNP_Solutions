using System.Text.Json;
using BlazorApp1.Models;

namespace BlazorApp1.Services;

public class EmailService : IEmailService

{
    private readonly List<Email> _emails;

    public EmailService()
    {
        _emails = new List<Email>
            {
                new Email("Himal", "Rachana Sharma", "Book", "Did yo like new book?", DateTime.Now),
                new Email("Ramesh", "Rachana Sharma", "Pen", "I need new pen", DateTime.Now),
                new Email("Rachana Sharma", "Dilu", "work", "I am going to work tomarrow", DateTime.Now),
                new Email("Gita", "Rachana Sharma", "Holiday", "I need holiday ", DateTime.Now),
                new Email("Rachana Sharma", "Prabina", "School", "My new school is very beoutiful", DateTime.Now)
            }
            ;
    }

    public Task SendEmail(Email email)
    {
        email.TimeSent = DateTime.Now;
        

        Console.WriteLine(JsonSerializer.Serialize(email));
        _emails!.Add(email);
        return Task.CompletedTask;    }

    public Task<List<Email>> GetEmails()
    {
        return Task.FromResult(_emails);
    }
    
}