using CursovaRobota.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota
{
    public class User
    {
        public string UserName;
        public double Balance;
        public User(UserEntity user)
        {
            this.UserName = user.UserName;
            this.Balance = user.Balance;
        }
        
    }
}
