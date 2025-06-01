using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ToDoListHW.Services;

namespace ToDoListHW.Pages
{
    public class NewTaskModel : PageModel
    {
        public readonly ITaskService _taskService;

        [BindProperty]
        public string? Title { get; set; }

        [BindProperty]
        public string? Description { get; set; }

        public NewTaskModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public void OnGet()
        {

        }

        public void OnPost() 
        {
            _taskService.CreateTask(Title, Description);
        }
    }
}
