using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListHW.Models;
using ToDoListHW.Services;

namespace ToDoListHW.Pages
{
    public class TasksModel : PageModel
    {

        public List<TaskItem> Tasks { get; private set; }

        public ITaskService TaskService { get; private set; }

        public TasksModel(ITaskService taskService)
        {
            TaskService = taskService;
        }
        public void OnGet()
        {
            Tasks = TaskService.GetAllTasks();
        }
        public void OnPostDeleteTask(ulong taskId)
        {
            TaskService.DeleteTask(taskId);
        }
    }
}
