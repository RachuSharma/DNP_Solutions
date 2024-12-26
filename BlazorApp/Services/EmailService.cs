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
                new Email("Himal", "Rachu", "Book", "aaaaaaaaa", DateTime.Now),
                new Email("Ramesh", "Rachu", "Pen", "bbbbbbbbbbbbbbbb", DateTime.Now),
                new Email("Sita", "Rachu", "work", "ccccccccccccc", DateTime.Now),
                new Email("Gita", "Rachu", "Holiday", "ddddddddddd", DateTime.Now),
                new Email("Hari", "Rachu", "School", "eeeeeeeee", DateTime.Now)
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