using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Numerics;
using ToDoListHW.Services;

namespace ToDoListHW.Pages
{
    public class NewTaskModel : PageModel
    {
        public readonly ITaskService _taskService;

        [BindProperty]
        [Required(ErrorMessage ="������ ������ ����� ��������!")]
        [MinLength(5, ErrorMessage= "�������� ������ ������� ��������!")]
        [MaxLength(100, ErrorMessage ="�������� ������ ������� �������!")]
        public string? Title { get; set; }

        [BindProperty]
        [MaxLength(400, ErrorMessage = "�������� ������ ������� �������!")]
        public string? Description { get; set; }

        public string? ErrorMessage { get; private set; }

        public NewTaskModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public void OnGet()
        {

        }

        public IActionResult OnPost() 
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "������� ������������ ������!";
                return Page();
            }
            _taskService.CreateTask(Title, Description);
            return RedirectToPage("Tasks");
        }
    }
}
