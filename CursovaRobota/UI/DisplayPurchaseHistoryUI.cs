using CursovaRobota.DB;
using CursovaRobota.DB.Services;
using CursovaRobota.DB.Services.Base;
using CursovaRobota.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.UI
{
    public class DisplayPurchaseHistoryUI : IUserInterface
    {
        IUserService userService;
        public void Action(DbContext context, User currentUser)
        {
            Console.WriteLine("");
            Console.WriteLine($"Username: {currentUser.UserName}, Balance: {currentUser.Balance}");
            UserService userService = new UserService(context);
            userService.DisplayUserPurchases(currentUser.UserName);
        }

        public void Description()
        {
            Console.WriteLine("Purchase History");
        }
    }
}
