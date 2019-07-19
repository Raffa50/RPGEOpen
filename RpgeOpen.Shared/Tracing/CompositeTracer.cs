using System;
using System.Collections.Generic;

namespace RpgeOpen.Shared.Tracing
{
    public class CompositeTracer : BaseTracer, IDisposable
    {
        private readonly IEnumerable<BaseTracer> tracers;

        public CompositeTracer(params BaseTracer[] tracers)
        {
            if (tracers.Length == 0)
                throw new ArgumentException("empty params", nameof(tracers));

            this.tracers = tracers;
        }

        public void Dispose()
        {
            foreach(var t in tracers)
            {
                var disposable = t as IDisposable;
                disposable?.Dispose();
            }
        }

        protected internal override void Trace(string message, TraceLevel level, string callerMemberName, string callerFilePath, int callerLineNumber, Func<object> context, Exception exception = null)
        {
            foreach (var t in tracers)
                t.Trace(message, level, callerMemberName, callerFilePath, callerLineNumber, context, exception);
        }
    }
}
