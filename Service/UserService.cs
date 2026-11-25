using System.Runtime.InteropServices;
using System.Text.Json;
using Repository;
using Entities;

namespace Service
{
    public class UserService : Iservice
    {

        IRepository r;
        public UserService(IRepository userR)
        {
            r = userR;
        }

        public Task<IEnumerable<Users>> Get()
        {
            return r.Get();
        }
        public async Task<Users> GetById()
        {
            return await r.GetById();
        }
        public async Task<Users> Login(LogUsers loguser)
        {
            return await r.Login(loguser);
        }
        public async Task<Users> Post(Users user)
        {
            return await r.Post(user);
        }
        public async void Put(int id, Users userToUpdae)
        {
            r.Put(id, userToUpdae);
        }
        // public Users AddUser(Users users)
        // {
        //         return r.Post(users);
        // }
        // public Task<Users> GetUser(LogUsers users)
        // {
        //         return r.Login(users);
        // }
        //public void Update(int id, Users users)
        //{
        //         r.Put(id, users);
        //}
    }
    }


