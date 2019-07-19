using System;
using System.IO;

namespace RpgeOpen.Shared.Tracing
{
    public class FileTracer : BaseTracer, IDisposable
    {
        private readonly StreamWriter stream;

        public FileTracer(string file) {
            stream = File.CreateText(file);
            stream.AutoFlush = true;
        }

        protected internal override void Trace(string message, TraceLevel level, string callerMemberName, string callerFilePath, int callerLineNumber, Func<object> context = null, Exception exception = null)
        {
            stream.WriteLine(
                TraceUtils.GetTrace(message, level, callerMemberName, callerFilePath, callerLineNumber, context, exception)
            );
        }

        public void Dispose()
        {
            stream.Dispose();
        }
    }
}
