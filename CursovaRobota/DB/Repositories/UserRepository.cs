using CursovaRobota.DB.Entities;
using CursovaRobota.DB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB.Repositories
{
    public class UserRepository : IUserRepository
    {
        private DbContext context;
        public UserRepository(DbContext context)
        {
            this.context = context;
        }

        public void Create(UserEntity user)
        {
            context.Users.Add(user);
        }


        public IEnumerable<UserEntity> Read()
        {
            return context.Users;
        }

        public void Update(UserEntity user)
        {
            var updateUser = context.Users.ToList().Find(x => x.UserName == user.UserName);
            updateUser.Balance+=user.Balance;
            
            if(user.PurchasedItems!=null) { updateUser.PurchasedItems.Add(user.PurchasedItems[0]); }
            
            
            
        }
    }
}
