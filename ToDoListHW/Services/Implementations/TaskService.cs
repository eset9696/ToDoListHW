using ToDoListHW.Models;

namespace ToDoListHW.Services.Implementations
{
    public class TaskService : ITaskService
    {
        public List<TaskItem> GetAllTasks()
        {
            return new List<TaskItem>() { 
                new TaskItem(){Id = 0, TaskName = "Вытереть пыль", CreationTime = DateTime.Now.ToString()},
                new TaskItem(){Id = 2, TaskName = "Приготовить ужин", TaskDescription = "Что-нибудь из картошки", CreationTime = DateTime.Now.ToString()}
            };
        }
    }
}
