namespace Mission08_Team0109.Models
{
    public class ITaskRepository
    {
        IQueryable<TaskItem> Tasks { get; }
        IQueryable<TaskItem> Categories { get; }

        void AddTask(TaskItem task);
        void UpdateTask(TaskItem task);
        void DeleteTask(TaskItem task);
        void SaveTask();
    }
}
