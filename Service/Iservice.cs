using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface Iservice
    {
        Task<IEnumerable<Users>>Get();
        Task<Users>GetById(int id);
        Task<Users> Login(LogUsers loguser);
        Task<Users> Post(Users user);
        void Put(int id, Users userToUpdae);
        //public Users AddUser(Users users);
        //public Users GetUser(LogUsers users);
        //public void Update(int id, Users users);

    }
}
