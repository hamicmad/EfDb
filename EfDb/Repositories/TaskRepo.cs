using EfDb.Enums;
using Microsoft.EntityFrameworkCore;

namespace EfDb.Repositories
{
    public class TaskRepo
    {
        public static void CreateTask(AppEfContext db, int complexity, int hours, int status, string description)
        {
            var task = new Task()
            {
                Complexity = (EnumTaskComplexity.TaskComplexity)complexity,
                Hours = hours,
                Status = (EnumTaskStatus.Status)(TaskStatus)status,
                Description = description
            };
            db.Tasks.Add(task);
            db.SaveChanges();
        }

        public static List<Task> ReadTasks(AppEfContext db)
        {
            return db.Tasks.Include(t => t.User).ToList();
        }

        public static void UpdateTask(AppEfContext db, int id)
        {
            var task = db.Tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                //Изменения
                db.SaveChanges();
            }
        }

        public static void DeleteTask(AppEfContext db, int id)
        {
            var task = db.Tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                db.Tasks.Remove(task);
                db.SaveChanges();
            }
        }

        public static void AddUserToTask(AppEfContext db, string UsName, int taskId)
        {
            var task = db.Tasks.FirstOrDefault(t => t.Id == taskId);

            task.Status = (EnumTaskStatus.Status)2;
            task.User = db.Users.FirstOrDefault(u => u.SecondName == UsName);
            db.SaveChanges();
        }
    }
}
