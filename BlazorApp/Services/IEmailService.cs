using BlazorApp1.Models;

namespace BlazorApp1.Services;

public interface IEmailService
{
    public Task SendEmail (Email email);
    
    Task<List<Email>> GetEmails();
}