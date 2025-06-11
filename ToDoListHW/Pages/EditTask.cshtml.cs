using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using ToDoListHW.Services;

namespace ToDoListHW.Pages
{
    public class EditTaskModel : PageModel
    {
        public readonly ITaskService _taskService;

        public int _taskId { get; private set; }

        [BindProperty]
        [Required(ErrorMessage = "Задача должна иметь название!")]
        [MinLength(5, ErrorMessage = "Название задачи слишком короткое!")]
        [MaxLength(100, ErrorMessage = "Название задачи слишком длинное!")]
        public string? Title { get; set; }

        [BindProperty]
        [MaxLength(400, ErrorMessage = "Описание задачи слишком длинное!")]
        public string? Description { get; set; }

        public string? ErrorMessage { get; private set; }

        public EditTaskModel(ITaskService taskService)
        {
            _taskService = taskService;
        }


        public void OnGet(int taskId, string taskTitle, string taskDesctr)
        {
            _taskId = taskId;
            Title = taskTitle;
            Description = taskDesctr;
        }


        public IActionResult OnPostEdit(int taskId)
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "Указаны некорректные данные!";
                return Page();
            }

            _taskService.EditTask(taskId, Title, Description);

            return RedirectToPage("Tasks");
        }
    }
}
