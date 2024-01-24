using CursovaRobota.DB;
using CursovaRobota.DB.Services;
using CursovaRobota.DB.Services.Base;
using CursovaRobota.UI.Base;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.UI
{
    public class LogInOrRegister 
    {
        IUserService userService;
        public LogInOrRegister(DbContext context)
        {
            userService = new UserService(context);
        }
        public User Action()
        {
            User currentUser;
            Console.WriteLine("1. Log in");
            Console.WriteLine("2. Register");
         
            while(true){
                string choise = Console.ReadLine();
                if (int.TryParse(choise, out int number))
                {
                    if (number == 1) { currentUser = new User(userService.LogIn());return currentUser; }
                    else if (number == 2) { currentUser = new User(userService.CreateUser()); Console.WriteLine("You were registered. "); return currentUser; }
                    
                }
                Console.WriteLine("Enter 1 or 2");
            }
        }

                        
    }
}
