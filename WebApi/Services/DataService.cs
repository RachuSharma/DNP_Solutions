using WebApi.Entities;

namespace WebApi;

public class DataService: IDataService
{
    private readonly List<Project> _projects = new();
    private readonly List<UserStory> _userStories = new();
    
    public DataService()
    {
        //adding dummy data
        _projects.Add(new Project
        {
            Id = 1,
            Title = "Project 1",
            Status = "Active",
            Responsible = "Himal sharma",
            UserStory = new List<UserStory>
            {
                new UserStory
                {
                    Id = 1,
                    Description = "User Story 1",
                    Estimate = "5"
                },
                new UserStory
                {
                    Id = 2,
                    Description = "User Story 2",
                    Estimate = "8"
                }
            }
        });   
        _projects.Add(new Project
        {
            Id = 2,
            Title = "Project 2",
            Status = "Active",
            Responsible = "Rachana Doe",
            UserStory = new List<UserStory>
            {
                new UserStory
                {
                    Id = 1,
                    Description = "User Story 3",
                    Estimate = "3"
                },
                new UserStory
                {
                    Id = 2,
                    Description = "User Story 4",
                    Estimate = "13"
                }
            }
        });
        
        
    }
    public void  AddProject(Project project)
    {
        project.Id = _projects.Any()
            ? _projects.Max(p => p.Id) + 1
            : 1;
        _projects.Add(project);
    }
    public Project GetProjectById(int projectId)
    {
        var project = _projects.SingleOrDefault(p => p.Id == projectId);
        if (project is null)
        {
            throw new Exception($"Project not found with id '{projectId}'");
        }

        return project;
    }


    public IQueryable<Project> GetProjects(string? status = null, string? responsible = null)
    {
        var query = _projects.AsQueryable();
        if (!string.IsNullOrWhiteSpace(status))
        {
            query = query.Where(p => p.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrWhiteSpace(responsible))
        {
            query = query.Where(p => p.Responsible.Equals(responsible, StringComparison.OrdinalIgnoreCase));
        }

        return query;
    }

    public void DeleteProjectAsync(int projectId )
    {

        var projectTORemove = _projects.SingleOrDefault(p => p.Id == projectId);
        if (projectTORemove is null)
        {
            throw new Exception($"projectID{projectId} not found to delete");
        }

        _projects.Remove(projectTORemove);
    }
    public void AddUserStory(int projectId, UserStory userStory)
    {
        var project = _projects.FirstOrDefault(p => p.Id == projectId);
        if (project == null) throw new Exception("Project not found");

        userStory.Id = project.UserStory.Any() ? 
            project.UserStory.Max(u => u.Id) + 1: 1;
        project.UserStory.Add(userStory);
    }

    public UserStory GetUserStoryById(int projectId, int userStoryId)
    {
        var project = _projects.SingleOrDefault(p => p.Id == projectId);
        if (project == null)
        {
            throw new Exception($"Project with ID '{projectId}' not found.");
        }

        var userStory = project.UserStory.SingleOrDefault(u => u.Id == userStoryId);
        if (userStory == null)
        {
            throw new Exception($"User story with ID '{userStoryId}' not found in project '{projectId}'.");
        }

        return userStory;

    }

    public void DeleteUserStoryAsync(int projectId, int userStoryId)
    {
        var project = _projects.SingleOrDefault(p => p.Id == projectId);
        if (project == null)
        {
            throw new Exception($"Project with ID '{projectId}' not found.");
        }

        var userStoryToRemove = project.UserStory.SingleOrDefault(u => u.Id == userStoryId);
        if (userStoryToRemove == null)
        {
            throw new Exception($"User story with ID '{userStoryId}' not found in project '{projectId}'.");
        }

        project.UserStory.Remove(userStoryToRemove);
    }
    
}