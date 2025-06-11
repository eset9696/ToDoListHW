using ToDoListHW.Models;

namespace ToDoListHW.Services
{
    public interface ITaskService
    {
        public List<TaskItem> GetAllTasks();

        public void CreateTask(string taskName, string taskDescr);
        public void DeleteTask(uint taskId);
    }
}
