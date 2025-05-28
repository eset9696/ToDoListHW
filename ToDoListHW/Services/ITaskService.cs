using ToDoListHW.Models;

namespace ToDoListHW.Services
{
    public interface ITaskService
    {
        public List<TaskItem> GetAllTasks();
    }
}
