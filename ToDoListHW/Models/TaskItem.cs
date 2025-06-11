namespace ToDoListHW.Models
{
    public class TaskItem
    {
        public required uint Id { get; set; }

        public required string TaskName { get; set; }

        public string? TaskDescription { get; set; }

        public string? CreationTime { get; set; }

    }
}
