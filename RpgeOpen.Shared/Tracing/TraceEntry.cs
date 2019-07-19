using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RpgeOpen.Shared.Tracing
{
    [JsonObject(ItemNullValueHandling = NullValueHandling.Ignore)]
    internal class TraceEntry
    {
        private static readonly JsonSerializer SafeSerializer = JsonSerializer.CreateDefault(
            new JsonSerializerSettings { ReferenceLoopHandling = ReferenceLoopHandling.Ignore }
        );

        public DateTimeOffset dt { get; set; } = DateTimeOffset.UtcNow;
        public string Host { get; set; } = Environment.MachineName;

        [JsonConverter(typeof(StringEnumConverter))]
        public TraceLevel level { get; set; }

        public string scope { get; set; }

        [JsonExtensionData]
        public IDictionary<string, JToken> ExtensionData { get; } = new Dictionary<string, JToken>();

        public string message { get; set; }
        public string callerMemberName { get; set; }
        public string callerFilePath { get; set; }
        public int callerLineNumber { get; set; }
        public JToken context { get; set; }
        public JToken exception { get; set; }

        public TraceEntry(
            string message,
            TraceLevel level,
            Func<object> context,
            Exception exception,
            string callerMemberName,
            string callerFilePath,
            int callerLineNumber
        )
        {
            this.message = message;
            this.level = level;
            this.callerMemberName = callerMemberName;
            this.callerFilePath = callerFilePath;
            this.callerLineNumber = callerLineNumber;
            this.context = SafeSerialize(context, true);
            this.exception = SafeSerialize(exception, true);

            StripNullValuedProperties(this.context, false);
            StripNullValuedProperties(this.exception, true);
        }

        private static JToken SafeSerialize(object obj, bool serializeError)
        {
            try
            {
                return obj == null ? JValue.CreateNull() : obj is Func<object> func ? SafeSerialize(func(), true) : JToken.FromObject(obj, SafeSerializer);
            }
            catch (Exception e)
            {
                return serializeError
                    ? new JObject() { { "!cannotSerialize!", SafeSerialize(e, false) } }
                    : (JToken)"!cannotSerialize!";
            }
        }

        private static void StripNullValuedProperties(JToken token, bool deep)
        {
            if (!(token is JObject obj))
                return;

            foreach (JProperty property in obj.Properties().Where(x => IsNull(x.Value)).ToList())
            {
                if (IsNull(property.Value))
                {
                    property.Remove();
                }
                else if (deep)
                {
                    StripNullValuedProperties(property.Value, true);
                }
            }
        }

        private static bool IsNull(JToken token)
        {
            return token.Type == JTokenType.Null || token is JValue value && value.Value == null;
        }
    }
}
