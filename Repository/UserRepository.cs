
using System.Reflection.Metadata;
using System.Text.Json;
using Entities;
namespace Repository
{
    public class UserRepository : IRepository
    {
        static string filePath = "User.txt";
        public Users AddUser(Users user)
        {

            int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
            user.Id = numberOfUsers + 1;
            string userJson = JsonSerializer.Serialize(user);
            System.IO.File.AppendAllText(filePath, userJson +
            Environment.NewLine);
            return user;
        }
        public Users GetUser(LogUsers loguser)
        {
            using (StreamReader reader = System.IO.File.OpenText(filePath))
            {
                string? currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
                    if (user.password == loguser.logpassword)
                        return user;
                }
            }
            return null;
        }
        public void Update(int id, Users putuser)
        {
            List<Users> users = new List<Users>();

            using (StreamReader reader = File.OpenText(filePath))
            {
                string line;

                while ((line = reader.ReadLine()) != null)
                {
                    Users user = JsonSerializer.Deserialize<Users>(line);

                    if (user != null)
                    {
                        if (user.Id == id)
                        {
                            user = putuser;
                            user.Id = id;
                        }

                        users.Add(user);
                    }
                }
            }

            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (Users user in users)
                {
                    writer.WriteLine(JsonSerializer.Serialize(user));
                }
            }

        }
    }
}



