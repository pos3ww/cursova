using CursovaRobota.DB;
using CursovaRobota.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.UI
{
    public class DisplayCurrentUserUI : IUserInterface
    {
        public void Action(DbContext context, User currentUser)
        {
            Console.WriteLine($"Username: {currentUser.UserName}, Balance: {currentUser.Balance}");
        }

        public void Description()
        {
            Console.WriteLine("Display Current User Info:");

        }
    }
}
