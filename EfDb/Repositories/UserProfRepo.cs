using Microsoft.EntityFrameworkCore;

namespace EfDb.Repositories
{
    public class UserProfRepo
    {
        public static void CreateProfile(AppEfContext db, string sName, string country, string city, string citizenship)
        {
            var uProfile = new UserProfile()
            {
                User = db.Users.FirstOrDefault(u => u.SecondName == sName),
                Country = country,
                City = city,
                Citizenship = citizenship
            };
            db.UserProfiles.Add(uProfile);
            db.SaveChanges();
        }

        public static UserProfile ReadProfile(AppEfContext db, string sName)
        {
            var uProfile = db.UserProfiles.FirstOrDefault(p => p.User.SecondName == sName);
            if (uProfile == null)
                return new UserProfile();

            return uProfile;
        }
        public static void UppdateProfile (AppEfContext db, string sName)
        {
            var profile = db.UserProfiles.FirstOrDefault(p => p.User.SecondName == sName);
            if (profile != null)
            {
                //Изменения 
                db.SaveChanges();
            }
        }
        
        public static void DeleteProfile(AppEfContext db, string sName)
        {
            var profile = db.UserProfiles.FirstOrDefault(p => p.User.SecondName == sName);
            if (profile != null)
            {
                db.UserProfiles.Remove(profile);
                db.SaveChanges();
            }
        }
    }
}
