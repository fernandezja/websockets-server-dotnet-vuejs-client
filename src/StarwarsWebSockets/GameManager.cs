using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarwarsWebSockets
{
    public sealed class GameManager
    {
        private static readonly Lazy<GameManager> lazy
                = new Lazy<GameManager>(() => new GameManager());

        public static GameManager Instance
            => lazy.Value;

        public Dictionary<string, Game> Games { get; private set; }

        private GameManager() {
            Clean();
        }

        public void Clean() {
            Games = new Dictionary<string, Game>();
        }

        public void SetEvent(string gameName, string eventName, string value)
        {
            if (!Games.ContainsKey(gameName))
            {
                Games[gameName] = new Game(gameName);
            }

            Games[gameName].SetEvent(eventName, value);
        }


        public void SetEvent(GameEvent gameEvent)
        {
            SetEvent(gameEvent.Game, gameEvent.Event, gameEvent.Value);
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var g in Games)
            {
                sb.Append(g.Value.ToString());
            }

            return sb.ToString();
        }

        public string ToJson()
        {
            var sb = new StringBuilder();
            sb.Append("[");

            var index = 0;
            foreach (var g in Games)
            {
                if (index >= 1)
                {
                    sb.Append(",");
                }
                sb.Append(g.Value.ToJson());

                index++;
                
            }
            sb.Append("]");

            return sb.ToString();
        }

    }
}
