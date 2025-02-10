using Octokit;

namespace GithubService
{
    public interface IGitHubService
    {
        Task<List<object>> GetPortfolio(string token);
        Task<List<Repository>> SearchRepositories(string? name, string? username, string? lang);
    }
}