
namespace EfDb.Repositories
{
    public class UserRepo
    {
        public static void CreateUser(AppEfContext db,string fName, string sName, DateTime dob)
        {
            var user = new User()
            {
                FirstName = fName,
                SecondName = sName,
                DateOfBirth = dob,
            };
            db.Users.Add(user);
            db.SaveChanges();
        }

        public static List<User> ReadUsers(AppEfContext db)
        {
            return db.Users.ToList();
        }

        public static void UpdateUser(AppEfContext db, string sName)
        {
            var user = db.Users.FirstOrDefault(u => u.SecondName == sName);
            if (user != null)
            {
                //Изменения
                db.SaveChanges();
            }
        }

        public static void DeleteUser(AppEfContext db, string sName)
        {
            var user = db.Users.FirstOrDefault(u => u.SecondName == sName);
            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
        }
    }
}
