using WebApi.Entities;

namespace WebApi;

public interface IDataService
{
    Task<Project> AddProjectAsync(Project project);
    Task<Project> GetProjectByIdAsync(int projectId);
    Task UpdateProjectAsync(int projectId,Project project);
    Task DeleteProjectAsync(int projectId);
    
    Task<IEnumerable<Project>> GetManyProjects(string? status = null, string? responsible = null);
    
    Task<UserStory> AddUserStoryAsync(int ProjectId ,UserStory userStory);
    
}