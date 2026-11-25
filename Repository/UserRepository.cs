
using Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using System.Text.Json;
namespace Repository
{
    
    public class UserRepository : IRepository
    {
        static string filePath = "User.txt";
        ITamarStore dbStore;
        public UserRepository (ITamarStore dbStores)//קונסטרקטור
        {
            dbStore = dbStores;
        }
        
        public async Task<IEnumerable<Users>> Get()
        {
            return await dbStore.Users.ToListAsync();
        }
        public async Task<Users> GetById(int  id)//החזרת משתמש עי ה id 
        {
            return await dbStore.Users.FindAsync(id);
        }
        public async Task<Users> Post(Users user)//הוספת משתמש
        {
            dbStore.Users.AddAsync(user);//מכין את הנתונים

            await dbStore.SaveChangeAsync() ;//הולך לדטה בייס
            return user;
        }
        public async Task<Users> Login(LogUsers logUsers)
        {
            return await dbStore.Users.Where(user => user.Email == logUsers.logemail && user.Password == logUsers.logpassword).FirstOrDefaultAsync();
        }

        public void Put(int id, Users userToUpdate)
        {
            userToUpdate.Id = id;
            dbStore.Users.Update(userToUpdate);//משפט sql לעדכון
        }











        //TamarStoreContext dbStore;

        //public async Task<Users> AddUser(Users user)
        //{

        //    //int numberOfUsers = System.IO.File.ReadLines(filePath).Count();
        //    //user.Id = numberOfUsers + 1;
        //    //string userJson = JsonSerializer.Serialize(user);
        //    //System.IO.File.AppendAllText(filePath, userJson +
        //    //Environment.NewLine);
        //    dbStore.Users.Add(user);
        //    await dbStore.SaveChangesAsync();

        //    return user;
        //}
        //public async Task<Users> GetUser(LogUsers loguser)
        //{
        //    //using (StreamReader reader = System.IO.File.OpenText(filePath))
        //    //{
        //    //    string? currentUserInFile;
        //    //    while ((currentUserInFile = reader.ReadLine()) != null)
        //    //    {
        //    //        Users user = JsonSerializer.Deserialize<Users>(currentUserInFile);
        //    //        if (user.Password == loguser.logpassword)
        //    //            return user;
        //    //    }
        //    //}
        //    //return null;
        //    return await dbStore.Users.Where(user => user.Password == loguser.logpassword && user.Email == loguser.logemail).FirstAsync();
        //}
        //public void Update(int id, Users putuser)
        //{

        //    //List<Users> users = new List<Users>();

        //    //using (StreamReader reader = File.OpenText(filePath))
        //    //{
        //    //    string line;

        //    //    while ((line = reader.ReadLine()) != null)
        //    //    {
        //    //        Users user = JsonSerializer.Deserialize<Users>(line);

        //    //        if (user != null)
        //    //        {
        //    //            if (user.Id == id)
        //    //            {
        //    //                user = putuser;
        //    //                user.Id = id;
        //    //            }

        //    //            users.Add(user);
        //    //        }
        //    //    }
        //    //}

        //    //using (StreamWriter writer = new StreamWriter(filePath))
        //    //{
        //    //    foreach (Users user in users)
        //    //    {
        //    //        writer.WriteLine(JsonSerializer.Serialize(user));
        //    //    }
        //    //}

        //}
    }
}
     
       
      

