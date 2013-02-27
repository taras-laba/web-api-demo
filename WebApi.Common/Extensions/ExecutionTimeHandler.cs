using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApi.Common.Extensions
{
    public class ExecutionTimeHandler : DelegatingHandler
    {
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            DateTime start = DateTime.Now;
            var task = await base.SendAsync(request, cancellationToken);
            DateTime end = DateTime.Now;
            task.Headers.Add("X-Execution-Time", (end-start).ToString());
            return task;
        }
    }
}
