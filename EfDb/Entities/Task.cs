using static EfDb.Enums.EnumTaskComplexity;
using static EfDb.EnumTaskStatus;

namespace EfDb
{
    public class Task
    {
        public int Id { get; set; }
        public TaskComplexity Complexity { get; set; }
        public int Hours { get; set; }
        public Status Status { get; set; }
        public string? Description { get; set; }

        public int? UserId { get; set; }
        public User? User { get; set; }

    }
}
