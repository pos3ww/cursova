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
    public class AddBalanceUI : IUserInterface
    {
        IUserService userService;
        public void Action(DbContext context, User currentUser)
        {
            Console.WriteLine("");
            userService = new UserService(context);
            string answer;
            Console.WriteLine("How much money would you like to add: ");
            while (true) {
                answer = Console.ReadLine();
                if (int.TryParse(answer, out int balanceAddition) && balanceAddition > 0)
                {
                    currentUser.Balance += balanceAddition;
                    userService.AddBalance(balanceAddition, currentUser.UserName);
                    Console.WriteLine($"Successfully added: {balanceAddition}, your current balance is: {currentUser.Balance}");
                    break;
                }
                Console.WriteLine("Invalid Input");
            }
            
        }

        public void Description()
        {
            Console.WriteLine("Add Balance");
        }
    }
}
