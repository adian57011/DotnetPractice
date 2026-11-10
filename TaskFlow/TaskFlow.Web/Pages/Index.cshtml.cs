using Microsoft.AspNetCore.Mvc.RazorPages;
using TaskFlow.Web.Models;
using TaskFlow.Web.Services;

namespace TaskFlow.Web.Pages;

public class IndexModel : PageModel
{
    private readonly ITaskService _taskService;

    public IReadOnlyList<TaskItem> Tasks { get; private set; } = [];

    public int TotalTasks => Tasks.Count;

    public int CompletedTasks =>
        Tasks.Count(task => task.IsCompleted);

    public int PendingTasks =>
        Tasks.Count(task => !task.IsCompleted);

    public IndexModel(ITaskService taskService)
    {
        _taskService = taskService;
    }

    public void OnGet()
    {
        Tasks = _taskService.GetAll();
    }
}
