using System.Threading.Tasks;
using EmpregosDevHiringAPI.External;
using EmpregosDevHiringAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmpregosDevHiringAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RepositoryController : ControllerBase
    {
        private readonly GitHubApi _gitHubApi;

        public RepositoryController(GitHubApi gitHubApi)
        {
            _gitHubApi = gitHubApi;
        }

        [HttpGet]
        public async Task<Response<GitHubRepositoriesResponse>> Search(string searchParameter = ".net core",
                                                                       int page = 1,
                                                                       int perPage = 10)
        {
            return await _gitHubApi.SearchRepositories(searchParameter, page, perPage);
        }
    }
}