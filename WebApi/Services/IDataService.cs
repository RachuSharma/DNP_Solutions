using WebApi.Entities;

namespace WebApi;

public interface IDataService
{
    Task<Project> AddProjectAsync(Project project);
    Task<Project> GetProjectByIdAsync(int projectId);
    Task UpdateProjectAsync(Project project);
    Task DeleteProjectAsync(int projectId);
    
    IQueryable<Project> GetManyProjects();
    
    Task<UserStory> AddUserStoryAsync(int ProjectId ,UserStory userStory);
    
}