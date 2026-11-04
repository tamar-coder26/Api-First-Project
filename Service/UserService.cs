using System.Runtime.InteropServices;
using System.Text.Json;
using Repository;
using Entities;

namespace Service
{
    public class UserService: Iservice
    {

        IRepository r;
        public UserService(IRepository userR)
        {
            r= userR;
        }
        public Users AddUser(Users users)
        {
            return r.AddUser(users);
        }
        public Users GetUser(LogUsers users)
        {
            return r.GetUser(users);
        }
        public void Update(int id,Users users)
        {
             r.Update(id,users);
        }
    }
}

