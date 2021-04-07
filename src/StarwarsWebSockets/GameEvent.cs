using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarwarsWebSockets
{
    public class GameEvent
    {
        [JsonPropertyName("game")]
        public string Game { get; set; }

        [JsonPropertyName("event")]
        public string Event { get; set; }

        [JsonPropertyName("value")]
        public string Value { get; set; }
    }
}
