using GithubService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GithubApi.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class GithubController : ControllerBase
    {
        private readonly IGitHubService _githubService;
        private readonly string _githubToken;
        public GithubController(IConfiguration configuration, IGitHubService gitHubService)
        {
            _githubService = gitHubService;
            _githubToken = configuration["GithubToken"];
        }

        [Route("repository")]
        [HttpGet]
        public async Task<IActionResult> GetRepository(string? repoName = null, string? userName = null, string? language = null)
        {
            var repos = await _githubService.SearchRepositories(repoName, userName, language);
            if (repos == null)
            {
                return NotFound();
            }
            return Ok(repos);
        }

        [Route("portfolio")]
        [HttpGet]
        public async Task<IActionResult> GetPortfolio()
        {
            var repos = await _githubService.GetPortfolio(_githubToken);
            if (repos == null)
            {
                return NotFound();
            }
            return Ok(repos);
        }
    }
}
