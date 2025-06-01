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

        public void OnPost() 
        {
            string? title = Request.Form["title"];
            string? descr = Request.Form["description"];

            _taskService.CreateTask(title, descr);
        }
    }
}
