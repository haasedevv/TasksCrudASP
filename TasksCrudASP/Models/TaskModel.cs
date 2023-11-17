using TaskStatus = TasksCrudASP.Enums.TaskStatus;

namespace TasksCrudASP.Models;

public class TaskModel
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public TaskStatus Status { get; set; }
}
