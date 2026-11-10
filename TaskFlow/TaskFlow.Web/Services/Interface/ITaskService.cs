using TaskFlow.Web.Models;

namespace TaskFlow.Web.Services;

public interface ITaskService
{
    List<TaskItem> GetAll();

    void Create(TaskItem task);
}
