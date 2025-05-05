using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using smartTaskManagementSystem.Models;

namespace smartTaskManagementSystem.Models
{
     public enum TaskStatus
        {
            ToDo,
            InProgress,
            Completed
        }

        public enum TaskCategory
        {
         
            Bug,
            Feature,
            Implement
        }

        public enum TaskPriority
        {
            Low,
            Medium,
            High
        }

        public class Task
        {
            public string Title { get; set; }
            public string Description { get; set; }
            public  TaskCategory taskcategory{ get; set; }
            public TaskPriority taskpriority { get; set; }
            public DateTime Deadline { get; set; }
            public DateTime CreatedDate { get; set; }
            public TaskStatus taskstatus { get; set; }
            public string User { get; set; }
        }
    
}

   
