using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using smartTaskManagementSystem.Services;
using smartTaskManagementSystem.Models;

namespace smartTaskManagementSystem.Services
{
    public class CLIParser
    {
        private TaskManager taskManager;
        private User _currentUser;

        public CLIParser(TaskManager taskManager)
        {
            this.taskManager = taskManager;
        }

        public void ParseCommand(string command)
        {
            var parts = command.Split(' ');
            switch (parts[0])
            {
                case "create-task":
                    CreateTask(parts);
                    break;
                case "assign-task":
                    AssignTask(parts);
                    break;
                case "update-status":
                    UpdateTaskStatus(parts);
                    break;
                case "filter-tasks":
                    FilterTasks(parts);
                    break;
                default:
                    Console.WriteLine("Invalid command.");
                    break;
            }
        }

        private void CreateTask(string[] parts)
        {
            if (parts.Length < 6)
            {
                Console.WriteLine("Invalid command format for create-task.");
                return;
            }

            string title = parts[1];
            string description = parts[2];
            Console.WriteLine(parts[3]);

            foreach (var part in parts)
            {
                Console.WriteLine(part);
            }

            TaskCategory category = (TaskCategory)Enum.Parse(typeof(TaskCategory),parts[3],true);
            TaskPriority priority = (TaskPriority)Enum.Parse(typeof(TaskPriority), parts[4], true);
            DateTime deadline = DateTime.Parse( parts[5]);
            /*
            if (!Enum.TryParse(parts[3], true, out TaskCategory category))
            {
                Console.WriteLine("Invalid task category.");
               
                return;
            }
            if (!Enum.TryParse(parts[4], true, out TaskPriority priority))
            {
                Console.WriteLine("Invalid task priority.");
                return;
            }
            if (!DateTime.TryParse(parts[5], out DateTime deadline))
            {
                Console.WriteLine("Invalid deadline format.");
                return;
            }*/

            taskManager.CreateTask(title, description, category, priority, deadline);
        }

        private void AssignTask(string[] parts)
        {
            if (parts.Length < 3)
            {
                Console.WriteLine("Invalid command format for assign-task.");
                return;
            }
            string title = parts[1];
            string user = parts[2];
            taskManager.AssignTask(title, user);
        }

        private void UpdateTaskStatus(string[] parts)
        {
            if (parts.Length < 3)
            {
                Console.WriteLine("Invalid command format for update-status.");
                return;
            }
            string title = parts[1];
            if (!Enum.TryParse(parts[2], true, out TaskStatus status))
            {
                Console.WriteLine("Invalid task status.");
                return;
            }
            taskManager.UpdateTaskStatus(title, status);
        }

        private void FilterTasks(string[] parts)
        {
            if (parts.Length < 2)
            {
                Console.WriteLine("Invalid command format for filter-tasks.");
                return;
            }
            Func<Task, bool> predicate = task => task.taskcategory.ToString() == parts[1];
            var filteredTasks = taskManager.FilterTasks(predicate);
            foreach (var task in filteredTasks)
            {
                Console.WriteLine($"Task: {task.Title}, Status: {task.taskstatus}, Priority: {task.taskpriority}, Deadline: {task.Deadline}");
            }
        }

        public void SetCurrentUser(User currentUser)
        {
            if (currentUser == null)
            {
                throw new ArgumentNullException(nameof(currentUser), "Current user cannot be null.");
            }

            _currentUser = currentUser;
            Console.WriteLine($"Current user set to: {currentUser.Name}");
        }
    }
}
