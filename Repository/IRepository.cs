using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repository
{
    public interface IRepository
    {
        //public Users AddUser(Users user);
        //public Users GetUser(LogUsers user);
        //public void Update(int id, Users putuser);

        Task<IEnumerable<Users>> Get();
        Task<Users> GetById(int id);
        Task< Users >Login(LogUsers loginUser);
        Task<Users> Post(Users user);
        void Put(int id, Users userToUpdate);
    }
}
