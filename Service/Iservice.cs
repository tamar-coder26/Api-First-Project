using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service
{
    public interface Iservice
    {
        public Users AddUser(Users users);
        public Users GetUser(LogUsers users);
        public void Update(int id, Users users);

    }
}
