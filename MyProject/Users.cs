//wwwroot is the folder for the html and js files, so the namespace for this class can be just MyProject
namespace MyProject.wwwroot
{
    //A class for one user is called User (singular), and each class gets its own file named after it (User.cs, LoginUser.cs).
    //In C#, public properties are written in PascalCase (UserEmail, FirstName, LastName, Password).
    //If you rename them, User.txt still has the old names, so read it with
    //new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
    public class Users
    {
        public string useremail { get; set; }
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public int Id { get; set; }


    }
    //A clearer name is LoginUser, with properties Email and Password
    public class LogUsers
    {
        public string logemail { get; set; }
        public string logpassword { get; set; }
    }
}
