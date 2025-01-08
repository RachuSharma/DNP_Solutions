using WebApi;
using WebApi.DTOs;
using WebApi.Entities;

public class DataService : IDataService
{
    private List<Project?> _projects = [];

//seeding dummy data
    public DataService()
    {
        _projects.Add(new Project
        {
            ProjectId = 1,
            Title = "Project 1",
            Status = "In Progress",
            Responsible = "John Doe",
            UserStories =
            [
                new UserStory
                {
                    UserStoryId = 1,
                    Description = "User Story 1",
                    Estimate = 3
                },

                new UserStory
                {
                    UserStoryId = 2,
                    Description = "User Story 2",
                    Estimate = 5
                }
            ]
        });
        _projects.Add(new Project
        {
            ProjectId = 2,
            Title = "Project 2",
            Status = "Finished",
            Responsible = "Jane Doe",
            UserStories =
            [
                new UserStory
                {
                    UserStoryId = 1,
                    Description = "User Story 1",
                    Estimate = 8
                },

                new UserStory
                {
                    UserStoryId = 2,
                    Description = "User Story 2",
                    Estimate = 13
                }
            ]
        });
    }

    public Task<Project> AddProjectAsync(Project project)
    {
        Console.WriteLine(_projects.Count);
        project.ProjectId = _projects.Any()
            ? _projects.Max(p => p.ProjectId) + 1
            : 1;
        _projects.Add(project);
        Console.WriteLine(_projects.Count);
        return Task.FromResult(project);
        
    }

    public Task<Project> GetProjectByIdAsync(int projectId)
    {
        var project = _projects.FirstOrDefault(p => p.ProjectId == projectId);
        if (project is null)
        {
            throw new Exception($"Post with ID '{projectId}' not found");
        }

        return Task.FromResult(project);
    }

    public Task UpdateProjectAsync(int projectId, Project project)
    {
        Project? existingPost = _projects.SingleOrDefault(p => p.ProjectId == project.ProjectId);
        if (existingPost is null)
        {
            throw new Exception($"Post with ID '{project.ProjectId}' not found");
        }

        _projects.Remove(existingPost);
        _projects.Add(project);

        return Task.CompletedTask;
    }

    public Task DeleteProjectAsync(int projectId)
    {
        var projectToRemove = _projects.SingleOrDefault(p => p.ProjectId == projectId);
        if (projectToRemove is null)
        {
            throw new Exception(
                $"Post with ID '{projectId}' not found");
        }

        _projects.Remove(projectToRemove);
        return Task.CompletedTask;
        
    }

    public Task<IEnumerable<Project>> GetManyProjects(string? status = null, string? responsible = null)
    {
       
        IEnumerable<Project> filteredProjects = _projects;

        if (!string.IsNullOrEmpty(status))
        {
            filteredProjects = filteredProjects.Where(p => p.Status.Equals(status, StringComparison.OrdinalIgnoreCase));
        }

        if (!string.IsNullOrEmpty(responsible))
        {
            filteredProjects = filteredProjects.Where(p => p.Responsible.Equals(responsible, StringComparison.OrdinalIgnoreCase));
        }

        return Task.FromResult(filteredProjects);
    }

    public Task<UserStory> AddUserStoryAsync(int ProjectId, UserStory userStory)
    {
        var project = _projects.SingleOrDefault(p => p.ProjectId == ProjectId);
        if (project is null)
        {
            throw new Exception($"Post with ID '{ProjectId}' not found");
        }

        userStory.UserStoryId = project.UserStories.Any()
            ? project.UserStories.Max(p => p.UserStoryId) + 1
            : 1;
        project.UserStories.Add(userStory);
        return Task.FromResult(userStory);
    }
}
