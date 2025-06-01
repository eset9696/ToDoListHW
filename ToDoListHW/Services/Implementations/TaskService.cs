using ToDoListHW.Models;

namespace ToDoListHW.Services.Implementations
{
    public class TaskService : ITaskService
    {
        private List<TaskItem> _tasks = new List<TaskItem>();
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
        }
    }
}
