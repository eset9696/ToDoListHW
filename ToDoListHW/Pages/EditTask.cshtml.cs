using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Headers;
using System.Numerics;
using ToDoListHW.Models;
using ToDoListHW.Services;

namespace ToDoListHW.Pages
{
    public class EditTaskModel : PageModel
    {
        public readonly ITaskService _taskService;

        [BindProperty(Name = "taskId", SupportsGet = true)]
        public ulong? TaskId { get; set; }

        [BindProperty]
        [Required(ErrorMessage = "������ ������ ����� ��������!")]
        [MinLength(5, ErrorMessage = "�������� ������ ������� ��������!")]
        [MaxLength(100, ErrorMessage = "�������� ������ ������� �������!")]
        public string? Title { get; set; }

        [BindProperty]
        [MaxLength(400, ErrorMessage = "�������� ������ ������� �������!")]
        public string? Description { get; set; }

        public string? ErrorMessage { get; private set; }

        public EditTaskModel(ITaskService taskService)
        {
            _taskService = taskService;
        }

        public IActionResult OnGet()
        {
            TaskItem? task = _taskService.GetTask(TaskId);

            if (task == null)
            {
                return RedirectToPage("Tasks");
            }

            Title = task.TaskName;
            Description = task.TaskDescription;

            return Page();
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                ErrorMessage = "������� ������������ ������!";
                return Page();
            }
            
            TaskItem? task = _taskService.GetTask(TaskId);

            if (task == null)
            {
                return RedirectToPage("Tasks");
            }

            task.TaskName = Title;
            task.TaskDescription = Description;

            _taskService.UpdateTask(TaskId, task);
            return RedirectToPage("Tasks");
        }
    }
}
