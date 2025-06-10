using System.Text.Json;
using ToDoListHW.Models;

namespace ToDoListHW.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private List<TaskItem> _tasks;

        public TaskService()
        {
            try
            {
                string serializedTasks = File.ReadAllText("Tasks.json");
                _tasks = JsonSerializer.Deserialize<List<TaskItem>>(serializedTasks);
            }
            catch (FileNotFoundException)
            {
                _tasks = new List<TaskItem>();
            }
            
        }
        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        public void CreateTask(string title, string description)
        {
            TaskItem newTask = new TaskItem()
            {
                Id = 0,
                TaskName = title,
                TaskDescription = description,
                CreationTime = DateTime.Now.ToString(),
            };
            _tasks.Add(newTask);
            Save();
        }

        private void Save()
        {
            string serializedTasks = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Tasks.json", serializedTasks);
        }

        private void Load()
        {
            string serializedTasks = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Tasks.json", serializedTasks);
        }
    }
}
