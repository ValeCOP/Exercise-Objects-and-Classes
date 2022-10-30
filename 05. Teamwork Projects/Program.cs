using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.WebSockets;
using System.Security.Principal;

namespace _05._Teamwork_Projects
{
    public class Program
    {
        static void Main(string[] args)
        {
            List<Team> teamsList = new List<Team>();
            int count = int.Parse(Console.ReadLine());
            string input;
            for (int i = 0; i < count; i++)
            {
                input = Console.ReadLine();
                string[] commArr = input.Split("-",StringSplitOptions.RemoveEmptyEntries);
                string creator = commArr[0];
                string teamName = commArr[1];

                Team team = new Team(teamName, creator);
                
                if (!teamsList.Any(x=>x.TeamName == teamName) && (!teamsList.Any(x => x.TeamCreator == creator)))
                {
                    teamsList.Add(team);
                    Console.WriteLine($"Team {teamName} has been created by {creator}!");
                }
                else if (teamsList.Any(x => x.TeamCreator == creator))
                {
                    Console.WriteLine($"{creator} cannot create another team!");
                }
                else if (teamsList.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} was already created!");
                }

            }
            while ((input = Console.ReadLine()) != "end of assignment")
            {  
                string[] commArr = input.Split("->", StringSplitOptions.RemoveEmptyEntries);
                string member = commArr[0];
                string teamName = commArr[1];


                if (!teamsList.Any(x => x.TeamName == teamName))
                {
                    Console.WriteLine($"Team {teamName} does not exist!");
                }
                else if (teamsList.Any(x => x.Members.Contains(member)) || teamsList.Any(x => x.TeamCreator.Contains(member)))
                {
                    Console.WriteLine($"Member {member} cannot join team {teamName}!");
                }
                else
                {
                    Team teamToJoin = teamsList.First(x => x.TeamName == teamName);
                    teamToJoin.Members.Add(member);
                }
            }
            List<Team> sortedTeamsList = teamsList.OrderByDescending(x => x.Members.Count)
                .ThenBy(x => x.TeamName)
                .Where(x => x.Members.Count > 0)
                .ToList();
            List<Team> sortedTeamsZero = teamsList
                .Where(x => x.Members.Count == 0)
                .ToList();

            foreach (Team item in sortedTeamsList)
            {
                Console.WriteLine($"{item.TeamName}");
                Console.WriteLine($"- {item.TeamCreator}");
                foreach (var item1 in item.Members)
                {
                    Console.WriteLine($"-- {item1}");
                }

            }
            Console.WriteLine("Teams to disband:");
            foreach (var item in sortedTeamsZero)
            {
                Console.WriteLine($"{item.TeamName}"); 
            }
        }
    }
    public class Team
    {
        public Team(string teamName, string teamCreator)
        {
            TeamName = teamName;
            TeamCreator = teamCreator;
            this.members = new List<string>();
        }
        


        public List<string> members;
        public List<string> Members
           => this.members;
        public string TeamName { get; set; }
        public string TeamCreator { get; set; }

       



    }
}
