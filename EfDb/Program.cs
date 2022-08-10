using EfDb;
using EfDb.Repositories;

var db = new AppEfContext();
while (true)
{
    Console.WriteLine("1.User   2.UserProfile   3.Team  4.Task");
    try
    {
        switch (Console.ReadLine())
        {
            case "1":
                switch (Console.ReadLine())
                {
                    case "1":
                        var fName = Console.ReadLine();
                        var sName = Console.ReadLine();
                        var dob = DateTime.Parse(Console.ReadLine());
                        UserRepo.CreateUser(db, fName, sName, dob);
                        Console.WriteLine("Success");
                        break;
                    case "2":
                        var users = UserRepo.ReadUsers(db);
                        foreach (var user in users)
                        {
                            Console.WriteLine($"Id: {user.Id}, fName: {user.FirstName}, sName: {user.SecondName}, ");
                        }
                        break;
                }
                break;
            case "2":
                switch (Console.ReadLine())
                {
                    case "1":
                        var sName1 = Console.ReadLine();
                        var country = Console.ReadLine();
                        var city = Console.ReadLine();
                        var cityzenship = Console.ReadLine();
                        UserProfRepo.CreateProfile(db, sName1, country, city, cityzenship);
                        Console.WriteLine("Success");
                        break;
                    case "2":
                        var sName2 = Console.ReadLine();
                        var userProf = UserProfRepo.ReadProfile(db, sName2);
                        Console.WriteLine($"fName: {userProf.User.FirstName}, sName: {userProf.User.SecondName},\n " +
                            $"{userProf.Country} {userProf.City} ");
                        break;
                }
                break;
            case "3":
                switch (Console.ReadLine())
                {
                    case "1":
                        var teamName = Console.ReadLine();
                        var managers = int.Parse(Console.ReadLine());
                        TeamRepo.CreateTeam(db, teamName, managers);
                        Console.WriteLine("Success");
                        break;
                    case "2":
                        var teams = TeamRepo.ReadTeams(db);
                        foreach (var team in teams)
                        {
                            Console.WriteLine(team.Name);
                            foreach (var u in team.Users)
                            {
                                Console.WriteLine(u.FirstName, u.SecondName);
                            }
                            Console.WriteLine();
                        }
                        break;
                    case "3":
                        var uName3 = Console.ReadLine();
                        var teamName3 = Console.ReadLine();
                        TeamRepo.AddToTeam(db, uName3, teamName3);
                        Console.WriteLine("Success");
                        break;
                }
                break;
            case "4":
                switch (Console.ReadLine())
                {
                    case "1":
                        var compl = int.Parse(Console.ReadLine());
                        var hours = int.Parse(Console.ReadLine());
                        var status = int.Parse(Console.ReadLine());
                        var deskription = Console.ReadLine();
                        TaskRepo.CreateTask(db, compl, hours, status, deskription);
                        Console.WriteLine("Success");
                        break;
                    case "2":
                        var uName4 = Console.ReadLine();
                        var taskId = int.Parse(Console.ReadLine());
                        TaskRepo.AddUserToTask(db, uName4, taskId);
                        Console.WriteLine("Success");
                        break;
                }
                break;
            default:
                return;
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    Console.Clear();
}
Console.ReadLine();