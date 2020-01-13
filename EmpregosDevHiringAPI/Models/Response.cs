using System.Collections.Generic;

namespace EmpregosDevHiringAPI.Models
{
    public class Response<T>
    {
        public T Content { get; set; }
        public int StatusCode { get; set; }
        public bool Successful { get; set; }
        public IEnumerable<string> Errors { get; set; }
    }
}
