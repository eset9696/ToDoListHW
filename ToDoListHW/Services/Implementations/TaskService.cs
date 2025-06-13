using System.Text.Json;
using System.Threading.Tasks;
using ToDoListHW.Models;

namespace ToDoListHW.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private List<TaskItem> _tasks;

        private ulong _nextTaskId;

        public TaskService()
        {
            try
            {
                string serializedTasks = File.ReadAllText("Tasks.json");
                _tasks = JsonSerializer.Deserialize<List<TaskItem>>(serializedTasks);
                if(_tasks == null)
                {
                    throw new Exception("Invalid tasks.json file");
                }
            }
            catch (Exception)
            {
                _tasks = new List<TaskItem>();
            }

            ulong maxTaskId = 0;

            foreach (TaskItem item in _tasks)
            {
                if(item.Id > maxTaskId)
                {
                    maxTaskId = item.Id;
                }
            }
            _nextTaskId = maxTaskId + 1;
        }
        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        public void CreateTask(string title, string description)
        {
            TaskItem newTask = new TaskItem()
            {
                Id = _nextTaskId++,
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

        public void DeleteTask(ulong taskId)
        {
            foreach (TaskItem item in _tasks)
            {
                if (item.Id == taskId)
                {
                    _tasks.Remove(item);
                    break;
                }
            }
            Save();
        }

        public TaskItem GetTask(ulong? id)
        {
            foreach (TaskItem item in _tasks)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public void UpdateTask(ulong? id, TaskItem task)
        {
            for(int i = 0; i < _tasks.Count; i++)
            {
                TaskItem item = _tasks[i];
                if (item.Id != id)
                {
                    continue;
                }
                _tasks[i] = task;  
            }
            Save();
        }
    }
}
