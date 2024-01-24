using CursovaRobota.DB.Entities;
using CursovaRobota.DB.Repositories;
using CursovaRobota.DB.Repositories.Base;
using CursovaRobota.DB.Services.Base;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB.Services
{
    public class UserService : IUserService
    {
        private IUserRepository userRepository;
        private IItemRepository itemRepository;
        public UserService(DbContext context)
        {
            userRepository = new UserRepository(context);
            itemRepository= new ItemRepository(context);
        }

        public void DisplayUserPurchases(string username)
        {
            var user = userRepository.Read().ToList().Find(x => x.UserName == username);
            Console.WriteLine($"User: {user.UserName}, Balance: {user.Balance}");
            foreach (var item in user.PurchasedItems)
            {
                Console.WriteLine($"Item: {item.ItemName}, total cost: {item.Price}, quantity: {item.Quantity}");
            }
        }

        public void AddBalance(double addBalance, string username)
        {
            UserEntity user=new UserEntity();
            user.UserName = username;
            user.Balance =+ addBalance;
            userRepository.Update(user);
            
        }

        public void BuyItem(ItemEntity item, int quantity, string userName)
        {
            item.Stock-= quantity;
            itemRepository.Update(item);
            UserEntity user=new UserEntity();
            user.UserName = userName;
            user.Balance = -item.Price * quantity;
            user.PurchasedItems= new List<PurchasedItemsEntity> { new PurchasedItemsEntity { ItemName=item.Name, Price = item.Price*quantity, Quantity = quantity }};
            userRepository.Update(user);
        }

        public UserEntity CreateUser()
        {
            bool valid_username=false;
            bool valid_password=false;
            string username = null;
            string password = null;
            while (valid_username == false) {
                Console.WriteLine("Enter username: ");
                username = Console.ReadLine();
                if (username != null)
                {
                    var user = userRepository.Read().ToList().Find(x => x.UserName == username);
                    if (user != null)
                    {
                        Console.WriteLine("Username is taken");
                    }
                    else
                    {
                        Console.WriteLine("Your username is: " + username);
                        valid_username = true;
                    }
                }
                else
                {
                    Console.WriteLine("Empty username!");
                }
            }
            while (valid_password == false)
            {
                Console.WriteLine("Enter password:");
                password = Console.ReadLine();
                
                if(password != null)
                {
                    Console.WriteLine("Confirm password");
                    string password_confirmation=Console.ReadLine();
                    if (password == password_confirmation)
                    {
                        Console.WriteLine("Your password is set");
                        valid_password = true;
                    }
                    else
                    {
                        Console.WriteLine("Passwords do not match, try again");
                    }
                }
            }
            UserEntity newUser= new UserEntity();
            newUser.UserName = username;
            newUser.Password = password;
            newUser.Balance = 0.0;
            newUser.Id = userRepository.Read().Count()+1;
            newUser.PurchasedItems = new List<PurchasedItemsEntity> { };
            userRepository.Create(newUser);
            return newUser;

        }


        public UserEntity LogIn()
        {
            string userName;
            string password;
            UserEntity user;
            var AllUsers = userRepository.Read().ToList();
            
            while (true) { 
                Console.WriteLine("Enter your username: ");
                userName = Console.ReadLine();
                if(AllUsers.Find(x => x.UserName == userName) != null)
                {
                    Console.WriteLine("Username found");
                    break;
                }
                else
                {
                    Console.WriteLine($"No user with username: {userName}");
                    Console.WriteLine("Try again");
                }
            }
            while (true)
            {
                Console.WriteLine("Enter your password: ");
                password = Console.ReadLine();
                if (AllUsers.Find(x => x.Password == password && x.UserName==userName) != null)
                {
                    Console.WriteLine("Successful LogIn");
                    user = AllUsers.Find(x => x.Password == password || x.UserName == userName);
                    break;
                }
                else
                {
                    Console.WriteLine("Passwords do not match");
                    Console.WriteLine("Try again");
                }
            }
            return user;

        }
    }
}
