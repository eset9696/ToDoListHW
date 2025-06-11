using System.Text.Json;
using ToDoListHW.Models;

namespace ToDoListHW.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private List<TaskItem> _tasks;
        private uint _taskId;

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
            _taskId = GetNextTaskId();
        }
        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        public void CreateTask(string title, string description)
        {
            TaskItem newTask = new TaskItem()
            {
                Id = _taskId++,
                TaskName = title,
                TaskDescription = description,
                CreationTime = DateTime.Now.ToString(),
            };
            _tasks.Add(newTask);
            SaveTasks();
        }

        public void DeleteTask(uint taskId)
        {
            foreach (var task in _tasks)
            {
                if (task.Id == taskId) _tasks.Remove(task);
            }
            //SaveTasks();
        }

        private void SaveTasks()
        {
            string serializedTasks = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Tasks.json", serializedTasks);
        }

        private uint GetNextTaskId()
        {
            uint nextTaskId = 0;

            foreach (var task in _tasks) 
                if(task.Id > nextTaskId) nextTaskId = task.Id;

            return nextTaskId;
        }
    }
}
