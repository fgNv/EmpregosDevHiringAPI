using System.Collections.Generic;

namespace EmpregosDevHiringAPI.Models
{
    public class GitHubRepositoriesResponse
    {
        public int TotalCount { get; set; }
        public bool IncompleteResults { get; set; }
        public IEnumerable<GitHubRepositoryItem> Items { get; set; }
    }
}
