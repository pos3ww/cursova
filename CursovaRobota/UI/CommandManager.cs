using CursovaRobota.DB;
using CursovaRobota.UI.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CursovaRobota.UI
{
    public class CommandManager
    {
        public List<IUserInterface> Commands { get; set; }
        public CommandManager()
        {
            Commands = new List<IUserInterface>();
        }
        public void AddCommand(IUserInterface command)
        {
            Commands.Add(command);
        }
        public void DisplayCommands()
        {
            int i = 1;
            foreach (var command in Commands)
            {
                Console.Write(i + ". ");
                command.Description();
                i++;
            }
        }
        public void ExecuteCommand(DbContext context, User currentUser)
        {
            int i;
            string userinput = Console.ReadLine();
            if (int.TryParse(userinput, out int commandNumber))
            {
                Console.WriteLine($"You chose command number: {commandNumber}");
                Commands[commandNumber - 1].Action(context, currentUser);
            }
            else
            {
                Console.WriteLine("Invalid input");
                return;
            }
        }
    }
}
