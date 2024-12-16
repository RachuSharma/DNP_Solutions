using WebApi.Entities;

namespace WebApi;

public interface IDataService
{
    void AddProject(Project project);
    Project GetProjectById(int projectId);
    IQueryable<Project> GetProjects(string? status = null, string? responsible = null);

    void DeleteProjectAsync(int projectId);
    void AddUserStory(int projectId, UserStory userStory);

    UserStory GetUserStoryById(int projectId, int userStoryId);
    void DeleteUserStoryAsync(int projectId, int userStoryId);
}