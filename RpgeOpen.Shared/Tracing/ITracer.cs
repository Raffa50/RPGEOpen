using System;
using System.Runtime.CompilerServices;

namespace RpgeOpen.Shared.Tracing
{
    public interface ITracer
    {
        void Debug(string message, Func<object> context = null, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0);
        void Info(string message, Func<object> context = null, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0);
        void Warning(string message, Func<object> context = null, Exception exception = null, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0);
        void Error(string message, Func<object> context = null, Exception exception = null, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0);
        void Critical(string message, Func<object> context = null, Exception exception = null, [CallerMemberName] string callerMemberName = "", [CallerFilePath] string callerFilePath = "", [CallerLineNumber] int callerLineNumber = 0);
    }
}
