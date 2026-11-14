namespace Entities
{
    public class Users
    {
        //Public properties are PascalCase in C# (UserEmail). Keep these names for now, the stored data needs them: add PropertyNameCaseInsensitive = true to the JSON options to read them in either case.
        public string useremail { get; set; }
        
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string password { get; set; }
        public int Id { get; set; }


    }
    public class LogUsers
    {
    
        public string logemail { get; set; }
        public string logpassword { get; set; }
    }
}
