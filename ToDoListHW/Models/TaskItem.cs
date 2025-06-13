namespace ToDoListHW.Models
{
    public class TaskItem
    {
        public required ulong Id { get; set; }

        public required string TaskName { get; set; }

        public string? TaskDescription { get; set; }

        public string? CreationTime { get; set; }

    }
}
