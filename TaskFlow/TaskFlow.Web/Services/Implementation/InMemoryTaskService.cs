using TaskFlow.Web.Models;

namespace TaskFlow.Web.Services.Implementation;

public class InMemoryTaskService : ITaskService
{
    private readonly List<TaskItem> _tasks =
    [
        new TaskItem
    {
        Id = 1,
        Title = "Learn Razor Pages",
        Description = "Understand the Razor Pages request lifecycle.",
        DueDate = DateTime.Today.AddDays(1),
        Priority = TaskPriority.High
    },
    new TaskItem
    {
        Id = 2,
        Title = "Configure TaskFlow",
        Description = "Set up the application layout and styling.",
        DueDate = DateTime.Today.AddDays(2),
        Priority = TaskPriority.Medium
    },
    new TaskItem
    {
        Id = 3,
        Title = "Study CSS fundamentals",
        Description = "Learn selectors, spacing, and Flexbox.",
        DueDate = DateTime.Today.AddDays(3),
        Priority = TaskPriority.Low,
        IsCompleted = true
    }
    ];

    public List<TaskItem> GetAll()
    {
        return _tasks;
    }

    public void Create(TaskItem task)
    {
        task.Id = _tasks.Count == 0
            ? 1
            : _tasks.Max(x => x.Id) + 1;

        _tasks.Add(task);
    }
}