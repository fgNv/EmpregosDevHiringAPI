using EmpregosDevHiringAPI.Models;
using System.Net;
using System.Threading.Tasks;

namespace EmpregosDevHiringAPI.External
{
    public class GitHubApi
    {
        private readonly HttpWrapper _httpWrapper;

        public GitHubApi(HttpWrapper httpWrapper)
        {
            _httpWrapper = httpWrapper;
        }

        public async Task<Response<GitHubRepositoriesResponse>> SearchRepositories(string searchParameter, int page, int perPage)
        {
            var url = $"https://api.github.com/search/repositories?" +
                     $"q={WebUtility.UrlEncode(searchParameter)}&" +
                     $"sort=stars&" +
                     $"order=desc&" +
                     $"page={page}&" +
                     $"per_page={perPage}";

            return await _httpWrapper.Get<GitHubRepositoriesResponse>(url);
        }
    }
}
