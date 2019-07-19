using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RpgeOpen.Shared.Tracing
{
    public static class TraceUtils
    {
        private static readonly JsonSerializerSettings serializationSettings =
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                PreserveReferencesHandling = PreserveReferencesHandling.None,
                MaxDepth = 4,
                Converters =
                {
                    new LimitedDepthExceptionConverter(3),
                }
            };

        public static string GetTrace(string message, TraceLevel level, string callerMemberName, string callerFilePath, int callerLineNumber, Func<object> context = null, Exception exception = null)
        {
            var t = new TraceEntry(message, level, context, exception, callerMemberName, callerFilePath, callerLineNumber);
            return JsonConvert.SerializeObject(t, serializationSettings);
        }

        private class LimitedDepthExceptionConverter : JsonConverter<Exception>
        {
            private readonly int desiredDepth;

            public override bool CanRead => false;

            public LimitedDepthExceptionConverter(int desiredDepth)
            {
                this.desiredDepth = desiredDepth;
            }

            public override void WriteJson(JsonWriter writer, Exception value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, Trim(value, desiredDepth));
            }

            private static object Trim(Exception e, int depth)
            {
                if (e == null)
                    return null;

                if (depth == 0)
                    return "-max serialization depth reached-";

                if (e is AggregateException ae)
                {
                    var innerExceptions = ae.InnerExceptions
                        .Select(ie => Trim(ie, depth - 1))
                        .ToList();

                    return new
                    {
                        ExceptionFullName = ae.GetType().FullName,
                        ExceptionMessage = ae.Message,
                        ae.StackTrace,
                        ae.Source,
                        ae.Data,
                        InnerExceptions = innerExceptions,
                    };
                }
                else
                {
                    return new
                    {
                        ExceptionFullName = e.GetType().FullName,
                        ExceptionMessage = e.Message,
                        e.StackTrace,
                        e.Source,
                        e.Data,
                        InnerException = Trim(e.InnerException, depth - 1),
                    };
                }
            }

            public override Exception ReadJson(JsonReader reader, Type objectType, Exception existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
