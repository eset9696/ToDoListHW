using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using ToDoListHW.Models;
using ToDoListHW.Services;

namespace ToDoListHW.Pages
{
    public class TasksModel : PageModel
    {

        public List<TaskItem> Tasks { get; private set; }

        private readonly ITaskService _taskService;

        public TasksModel(ITaskService taskService)
        {
            _taskService = taskService;
        }
        public void OnGet()
        {
            Tasks = _taskService.GetAllTasks();
        }
        public void OnPostDelete(int taskId) 
        {
            _taskService.DeleteTask(taskId);
            Tasks = _taskService.GetAllTasks();
        }
    }
}
