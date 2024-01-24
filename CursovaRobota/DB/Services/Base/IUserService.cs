using CursovaRobota.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB.Services.Base
{
    public interface IUserService
    {

        public UserEntity CreateUser();
        public UserEntity LogIn();
        public void AddBalance(double balance, string username);
        public void DisplayUserPurchases(string username);
        public void BuyItem(ItemEntity item, int quantity, string userName);


    }
}
