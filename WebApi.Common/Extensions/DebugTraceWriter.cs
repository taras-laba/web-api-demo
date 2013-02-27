using System;
using System.Diagnostics;
using System.Net.Http;
using System.Web.Http.Tracing;

namespace WebApi.Common.Extensions
{
    public class DebugTraceWriter : ITraceWriter
    {
        public void Trace(HttpRequestMessage request, string category, System.Web.Http.Tracing.TraceLevel level, Action<TraceRecord> traceAction)
        {
            TraceRecord record = new TraceRecord(request, category, level);
            traceAction(record);
            var message = string.Format("{0};{1};{2}", record.Operator, record.Operation, record.Message);
            Debug.WriteLine(message, record.Category);
        }
    }
}
