using Microsoft.Extensions.Caching.Memory;
using Octokit;

namespace GithubService
{
    public class CachedGitHubService : IGitHubService
    {
        private readonly IGitHubService _githubService;
        private readonly IMemoryCache _memoryCache;
        public CachedGitHubService(IGitHubService gitHubService, IMemoryCache memoryCache) {
            _githubService = gitHubService;
            _memoryCache = memoryCache;
        }
        public async Task<List<object>> GetPortfolio(string token)
        {
            if (_memoryCache.TryGetValue("portfolio_key", out var cachedPortfolio))
                return (List<object>)cachedPortfolio;
            var portfolio = await _githubService.GetPortfolio(token);
            var cacheOptions = new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(TimeSpan.FromSeconds(60)) //כל כמה זמן לעדכן
                .SetSlidingExpiration(TimeSpan.FromSeconds(30)); //אם לא בקשו 30 שניות למחוק 
            _memoryCache.Set("portfolio_key", portfolio);
            return portfolio;
        }

        public async Task<List<Repository>> SearchRepositories(string? name, string? username, string? lang)
        {
            return await _githubService.SearchRepositories(name, username, lang);
        }
    }
}
