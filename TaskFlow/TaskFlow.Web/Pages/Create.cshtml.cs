using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskFlow.Web.Models;
using TaskFlow.Web.Services;

namespace TaskFlow.Web.Pages;

public class CreateModel : PageModel
{
    private readonly ITaskService _taskService;

    public CreateModel(ITaskService taskService)
    {
        _taskService = taskService;
    }

    [BindProperty]
    public CreateTaskInput Input { get; set; } = new();

    public void OnGet()
    {
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
        {
            return Page();
        }

        var task = new TaskItem
        {
            Title = Input.Title.Trim(),
            Description = Input.Description.Trim(),
            Priority = Input.Priority!.Value,
            DueDate = Input.DueDate
        };

        _taskService.Create(task);

        TempData["SuccessMessage"] = "Task created successfully.";

        return RedirectToPage("/Index");
    }
}
