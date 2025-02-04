namespace Task_4._01
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<IPlayer> players = new List<IPlayer>();
            List<Team> teams = new List<Team>();
            string[] commands = Console.ReadLine().Split(' ');
            while (commands[0] != "exit")
            {
                switch (commands[0])
                {
                    case "create_team":
                        Team team = new Team(commands[1]);
                        teams.Add(team);
                        break;
                    case "create_player":
                        IPlayer player = new Player(commands[1], commands[2]);
                        players.Add(player);
                        Console.WriteLine($"Player {player.Name} with position {player.Position} created.");
                        break;

                    case "add_player":
                        Team teamToAdd = teams.FirstOrDefault(x => x.Name == commands[1]);
                        if (teamToAdd != null)
                        {
                            teamToAdd.add_player(commands[2], commands[3]);
                        }
                        else
                        {
                            Console.WriteLine("There's no existing such a team.");
                        }
                        break;
                    case "remove_player":
                        Team teamToRemoveFrom = teams.FirstOrDefault(x => x.Name == commands[1]);
                        if (teamToRemoveFrom != null)
                        {
                            teamToRemoveFrom.remove_player(commands[2]);
                        }
                        else
                        {
                            Console.WriteLine("There's no existing such a team.");
                        }
                        break;
                    case "print_team":
                        team = teams.FirstOrDefault(t => t.Name == commands[1]);
                        if (team != null)
                        {
                            team.SaveLogToFile(commands[2]);
                        }
                        else
                        {
                            Console.WriteLine("Team not found.");
                        }
                        break;
                    case "print_log_txt":
                        Team teamToPrintLog = teams.FirstOrDefault(x => x.Name == commands[1]);
                        if (teamToPrintLog != null)
                        {
                            teamToPrintLog.PrintLogToConsole();
                        }
                        else
                        {
                            Console.WriteLine($"Team {commands[1]} does not exist.");
                        }
                        break;
                }
                commands = Console.ReadLine().Split(' ');
            }
        }
    }
}
