using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListHW.Services;

namespace ToDoListHW.Pages
{
    public class NewTaskModel : PageModel
    {
        public readonly ITaskService _taskService;

        public NewTaskModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public void OnGet()
        {

        }

        public void OnPost(string Title, string Description) 
        {
            _taskService.CreateTask(Title, Description);
        }
    }
}
