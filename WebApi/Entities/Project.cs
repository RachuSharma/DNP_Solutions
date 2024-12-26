namespace WebApi.Entities;

public class Project
{
    public int ProjectId { get; set; } 
    public string Title { get; set; } 
    public string Status { get; set; }
    public string Responsible { get; set; }
    public List<UserStory> UserStories { get; set; }

    public Project(string title, string status, string responsible, List<UserStory> userStories)
    {
        Title = title;
        Status = status;
        Responsible = responsible;
        UserStories = userStories;
    }

    public Project()
    {
        
    }
}