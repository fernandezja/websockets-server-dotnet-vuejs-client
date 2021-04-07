using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace StarwarsWebSockets
{
    public class Game
    {
        public string Name { get; private set; }
        public Dictionary<string, int> Events { get; private set; }

        public Game(string gameName)
        {
            Name = gameName;
            Events = new Dictionary<string, int>();
        }

        public void SetEvent(string eventName, string value){

            if (!Events.ContainsKey(eventName))
            {
                Events[eventName] = 0;
            }

            Events[eventName]++;
        }

        public override string ToString()
        {
            var events = 0;
            var total = 0;
            var sb = new StringBuilder();

            sb.Append("Game > ");
            sb.Append(Name);
            sb.Append(" > ");
            
            foreach (var item in Events)
            {
                events++;
                total += item.Value;

                sb.Append(" | Evento ");
                sb.Append(item.Key);
                sb.Append(" (");
                sb.Append(item.Value);
                sb.Append(")");
            }

            return sb.ToString();
        }

        public string ToJson()
        {
            var events = 0;
            var total = 0;

            var gameDataJson = new
            {
                game = Name,
                events = new List<dynamic>()
            };

            foreach (var item in Events)
            {
                events++;
                total += item.Value;


                var eventoDataJson = new
                {
                    eventName = item.Key,
                    count = item.Value
                };

                gameDataJson.events.Add(eventoDataJson);
            }



            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true,
                IncludeFields = true
            };

            var dataJson = JsonSerializer.Serialize(gameDataJson, gameDataJson.GetType());

            return dataJson;
        }
    }
}
