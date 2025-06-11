using System.Text.Json;
using System.Threading.Tasks;
using ToDoListHW.Models;

namespace ToDoListHW.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private List<TaskItem> _tasks;
        private int _nextTaskId = 0;

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
                Id = GetNextTaskId(),
                TaskName = title,
                TaskDescription = description,
                CreationTime = DateTime.Now.ToString(),
            };
            _tasks.Add(newTask);
            SaveTasks();
        }

        public void DeleteTask(int taskId)
        {
            List<TaskItem> tasksUpdated = new List<TaskItem>();
            foreach (var task in _tasks)
            {
                if (task.Id == taskId) continue;
                tasksUpdated.Add(task);
            }
            _tasks = tasksUpdated;
            SaveTasks();
        }

        public void EditTask(int taskId, string taskName, string taskDescr)
        {
            foreach (var task in _tasks)
                if (task.Id == taskId)
                {
                    task.TaskName = taskName;
                    task.TaskDescription = taskDescr;
                }
            SaveTasks();
        }

        private void SaveTasks()
        {
            string serializedTasks = JsonSerializer.Serialize(_tasks, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText("Tasks.json", serializedTasks);
        }

        private int GetNextTaskId()
        {
            foreach (var task in _tasks) 
                if(task.Id >= _nextTaskId) _nextTaskId = task.Id + 1;

            return _nextTaskId;
        }
    }
}
