using System;
using smartTaskManagementSystem.Models;

namespace smartTaskManagementSystem.Services
{
    public class NotificationService
    {
        public void OnTaskAssigned(Task task)
        {
            Console.WriteLine($"Notification: Task \"{task.Title}\" has been assigned to {task.User}.");
        }

        public void OnTaskCompleted(Task task)
        {
            Console.WriteLine($"Notification: Task \"{task.Title}\" has been completed.");
        }

        public void OnTaskDeadlineApproaching(Task task)
        {
            Console.WriteLine($"Notification: Task \"{task.Title}\" deadline is approaching. Deadline: {task.Deadline}");
        }
    }
}
