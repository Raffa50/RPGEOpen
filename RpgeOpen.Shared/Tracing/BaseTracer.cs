using System;
using System.Runtime.CompilerServices;

namespace RpgeOpen.Shared.Tracing
{
    public abstract class BaseTracer : ITracer
    {
        protected abstract void Trace(string message, TraceLevel level, string callerMemberName, string callerFilePath, int callerLineNumber, Func<object> context, Exception exception = null);

        public void Critical(string message, Func<object> context = null, Exception exception = null, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            Trace(message, TraceLevel.CRITICAL, callerMemberName, callerFilePath, callerLineNumber, context, exception);
        }

        public void Debug(string message, Func<object> context = null, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            Trace(message, TraceLevel.DEBUG, callerMemberName, callerFilePath, callerLineNumber, context);
        }

        public void Error(string message, Func<object> context = null, Exception exception = null, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            Trace(message, TraceLevel.ERROR, callerMemberName, callerFilePath, callerLineNumber, context, exception);
        }

        public void Info(string message, Func<object> context = null, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            Trace(message, TraceLevel.INFO, callerMemberName, callerFilePath, callerLineNumber, context);
        }

        public void Warning(string message, Func<object> context = null, Exception exception = null, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0)
        {
            Trace(message, TraceLevel.WARNING, callerMemberName, callerFilePath, callerLineNumber, context, exception);
        }
    }
}
