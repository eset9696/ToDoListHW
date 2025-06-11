using ToDoListHW.Models;

namespace ToDoListHW.Services
{
    public interface ITaskService
    {
        public List<TaskItem> GetAllTasks();

        public void CreateTask(string taskName, string taskDescr);
        public void DeleteTask(int taskId);
        public void EditTask(int taskId, string taskName, string taskDescr);
    }
}
