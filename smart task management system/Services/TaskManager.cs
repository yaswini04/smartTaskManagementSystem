using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using smartTaskManagementSystem.Services;
using smartTaskManagementSystem.Models;
using System.Globalization;

namespace smartTaskManagementSystem.Services
{
    public class TaskManager
    {
        private List<Task> tasks = new List<Task>();
        private NotificationService notificationService;

        public event Action<Task> TaskAssigned;
        public event Action<Task> TaskCompleted;
        public event Action<Task> TaskDeadlineApproaching;

        public TaskManager(NotificationService notificationService)
        {
            this.notificationService = notificationService;

            TaskAssigned += notificationService.OnTaskAssigned;
            TaskCompleted += notificationService.OnTaskCompleted;
            TaskDeadlineApproaching += notificationService.OnTaskDeadlineApproaching;
            Thread deadlineMonitor = new Thread(DeadlineMonitor);
            deadlineMonitor.Start();
        }

        public void CreateTask(string title, string description, TaskCategory category, TaskPriority priority, DateTime deadline)
        {
            Task task = new Task
            {
                Title = title,
                Description = description,
                taskcategory = category,
                taskpriority = priority,
                taskstatus = TaskStatus.ToDo, // Default status
                Deadline = deadline,
                CreatedDate = DateTime.Now
            };

            if (tasks.Any(t => t.Title == title))
                throw new Exception("Duplicate Task Exception: Task with the same title already exists.");
            tasks.Add(task);
            Console.WriteLine($"Task \"{title}\" created.");
        }

        public void AssignTask(string title, string user)
        {
            Task task = tasks.Find(t => t.Title == title);
            if (task != null)
            {
                task.User = user;
                TaskAssigned?.Invoke(task);
                Console.WriteLine($"Task \"{title}\" assigned to {user}.");
            }
            else
            {
                Console.WriteLine($"Task \"{title}\" not found.");
            }
        }

        public void UpdateTaskStatus(string title, TaskStatus status)
        {
            var task = tasks.FirstOrDefault(t => t.Title == title);
            if (task == null)
                throw new Exception("Task not found.");
            task.taskstatus = status;
            if (status == TaskStatus.Completed)
                TaskCompleted?.Invoke(task);
        }

        public List<Task> FilterTasks(Func<Task, bool> predicate)
        {
            return tasks.Where(predicate).ToList();
        }

        private void DeadlineMonitor()
        {
            while (true)
            {
                foreach (var task in tasks)
                {
                    if (task.Deadline <= DateTime.Now.AddHours(24) && task.taskstatus != TaskStatus.Completed)
                    {
                        TaskDeadlineApproaching?.Invoke(task);
                    }
                }
                Thread.Sleep(10000);
            }
        }
    }
}
