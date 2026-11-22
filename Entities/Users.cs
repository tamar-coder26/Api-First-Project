namespace Entities
{
    public class Users
    {
        //In C#, properties are written in PascalCase: UserEmail. User.txt stores the current names: if you rename them, set PropertyNameCaseInsensitive = true in the JsonSerializerOptions, so the existing file still loads
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
