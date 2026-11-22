
//This using isn't used in this file: you can remove it
using System.Reflection.Metadata;
using System.Text.Json;
using Entities;
namespace Repository
{
    public class UserRepository
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
                    //Login checks only the password: should it also compare the email (loguser.logemail)?
                    if (user.password == loguser.logpassword)
                        return user;
                }
            }
            return null;
        }
        public void Update(int id, Users putuser)
        {
            string textToReplace = string.Empty;
            using (StreamReader reader =
            System.IO.File.OpenText(filePath))
            {
                string currentUserInFile;
                while ((currentUserInFile = reader.ReadLine()) != null)
                {
                    Users user =
                    JsonSerializer.Deserialize<Users>(currentUserInFile);
                    //Once the user with this id is found, does the loop need to keep reading the file? Consider a break
                    if (user.Id == id)
                        textToReplace = currentUserInFile;
                }
            }
            if (textToReplace != string.Empty)
            {
                string text = System.IO.File.ReadAllText(filePath);
                text = text.Replace(textToReplace, JsonSerializer.Serialize(putuser));
                System.IO.File.WriteAllText(filePath, text);
            }
        }
    }
}
      

