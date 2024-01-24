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
    public class PurchaseItemUI:IUserInterface
    {
        private IUserService userService;
        private IItemService itemService;
        public void Action(DbContext context, User currentUser)
        {
            UserService userService = new UserService(context);
            ItemService itemService = new ItemService(context);
            Console.WriteLine("Item List:");
            itemService.DisplayItems();
            
            
            while (true)
            {
                Console.WriteLine("Item to buy: ");
                string choice = Console.ReadLine();
                if (int.TryParse(choice, out int number))
                {
                    if (number >=1 && number <= 4) 
                    {
                        Console.WriteLine("Input quantity");
                        string quantityChoice= Console.ReadLine();
                        if(int.TryParse(quantityChoice, out int quantity) && quantity <= itemService.GetItemEntity(number).Stock && currentUser.Balance>= quantity* itemService.GetItemEntity(number).Price && quantity>0)
                        {
                            userService.BuyItem(itemService.GetItemEntity(number), quantity, currentUser.UserName);
                            currentUser.Balance-= quantity* itemService.GetItemEntity(number).Price;
                            Console.WriteLine($"Item was bought");
                            break;
                        }
                        Console.WriteLine("Invalid quantity");
                    }
                    
                }
                Console.WriteLine("Try again");
            }

        }
        public void Description()
        {
            Console.WriteLine("Buy Item");
        }
    }
}
