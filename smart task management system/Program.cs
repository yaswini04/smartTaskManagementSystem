using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using smartTaskManagementSystem.Exceptions;
using smartTaskManagementSystem.Models;
using smartTaskManagementSystem.Services;

namespace smartTaskManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            NotificationService notificationService = new NotificationService();
            TaskManager taskManager = new TaskManager(notificationService);
            CLIParser cliParser = new CLIParser(taskManager);

            Admin admin = new Admin("Bob");
            TeamMember teamMember1 = new TeamMember("Alice");
            TeamMember teamMember2 = new TeamMember("Charlie");
            TeamMember teamMember3 = new TeamMember("Demon");

            User currentUser = null;
            while (currentUser == null)
            {
                Console.WriteLine("Available users:");
                Console.WriteLine("1. Bob (Admin)");
                Console.WriteLine("2. Alice (TeamMember)");
                Console.WriteLine("3. Charlie (TeamMember)");
                Console.Write("Login as: ");
                string username = Console.ReadLine();

                switch (username.ToLower())
                {
                    case "bob":
                        currentUser = admin;
                        break;
                    case "alice":
                        currentUser = teamMember1;
                        break;
                    case "charlie":
                        currentUser = teamMember2;
                        break;
                    default:
                        Console.WriteLine("Invalid username. Please try again.");
                        break;
                }
            }

            cliParser.SetCurrentUser(currentUser);
            Console.WriteLine($"Logged in as {currentUser.Username} ({currentUser.Role})");

            while (true)
            {
                Console.Write($"{currentUser.Username}> ");
                string command = Console.ReadLine();
                try
                {
                    cliParser.ParseCommand(command);
                }
                catch (DuplicateTaskException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (InvalidUserException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (DeadlineInPastException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (UnauthorizedException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    }
}
