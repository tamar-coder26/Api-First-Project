using System;
using System.Collections.Generic;
using System.Text;
using Entities;

namespace Repository
{
    public interface IRepository
    {
        public Users AddUser(Users user);

        public Users GetUser(LogUsers user);
        public void Update(int id, Users putuser);

        
    }
}
