using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task_4._01
{
    public class Team
    {
		private string name;
		public string Name
		{
			get { return name; }
			set { name = value; }
		}
        public List<IPlayer> Players { get; set; }
        private ILog log;
        public Team(string name)
        {
            Name = name;
            Players = new List<IPlayer>();
            log = new TextLog();
            log.Log($"Team {name} created at {DateTime.Now}");
        }
        public void add_player(string playerName, string position)
        {
            IPlayer player = Players.FirstOrDefault(p => p.Name == playerName);
            if (player == null)
            {
                player = new Player(playerName, position);
                Players.Add(player);
                string logMessage = $"Player {playerName} with position {position} added to team " +
                    $"{Name} at {DateTime.Now}";
                log.Log(logMessage);
                Console.WriteLine(logMessage);
            }
            else
            {
                string logMessage = $"The player {player.Name} already exists in team {Name} at {DateTime.Now}";
                log.Log(logMessage);
                Console.WriteLine(logMessage);
            }
        }
        public void remove_player(string playerName)
        {
            IPlayer player = Players.FirstOrDefault(p => p.Name == playerName);
            if (player != null)
            {
                Players.Remove(player);
                string logMessage = $"Player {player.Name} removed from team {Name} at {DateTime.Now}";
                log.Log(logMessage);
                Console.WriteLine(logMessage);
            }
            else
            {
                string logMessage = $"No player named {playerName} found in team {Name} at {DateTime.Now}";
                log.Log(logMessage);
                Console.WriteLine(logMessage);
            }
        }
        public void SaveLogToFile(string filePath)
        {
            log.SaveLog(filePath);
        }
        public void PrintLogToConsole()
        {
            Console.WriteLine($"Log history for team {Name}:");
            Console.WriteLine(log.GetLog());
        }
    }
}
