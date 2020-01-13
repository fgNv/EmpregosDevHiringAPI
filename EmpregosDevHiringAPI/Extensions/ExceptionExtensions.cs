using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmpregosDevHiringAPI.Extensions
{
    internal static class ExceptionExtensions
    {
        public static IEnumerable<string> GetExceptionMessages(this Exception ex)
        {
            yield return ex.Message;
            if (ex.InnerException != null)
            {
                foreach(var inner in GetExceptionMessages(ex.InnerException))
                {
                    yield return inner;
                }
            }
        }
    }
}
