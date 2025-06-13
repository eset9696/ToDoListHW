using ToDoListHW.Models;

namespace ToDoListHW.Services
{
    public interface ITaskService
    {
        public List<TaskItem> GetAllTasks();

        public void CreateTask(string taskName, string taskDescr);
        public void DeleteTask(ulong id);
        public TaskItem GetTask(ulong? id);
        public void UpdateTask(ulong? id, TaskItem task);
    }
}
