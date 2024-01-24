using CursovaRobota.DB;
using CursovaRobota.DB.Entities;
using CursovaRobota.DB.Services;
using CursovaRobota.DB.Services.Base;
using CursovaRobota.UI;
using CursovaRobota.UI.Base;
using System.Diagnostics;
using System.Xml.Linq;

namespace CursovaRobota;
class Program
{
    static void Main(string[] args)
    {
        DbContext context = new DbContext();
        LogInOrRegister LoginOrRegister = new LogInOrRegister(context);
        User currentUser = LoginOrRegister.Action();
        CommandManager commandManager = new CommandManager();
        commandManager.Commands.Add(new DisplayItemsUI());
        commandManager.Commands.Add(new DisplayPurchaseHistoryUI());
        commandManager.Commands.Add(new AddBalanceUI());
        commandManager.Commands.Add(new PurchaseItemUI());
        commandManager.Commands.Add(new DisplayCurrentUserUI());
        while (true)
        {
            commandManager.DisplayCommands();
            commandManager.ExecuteCommand(context,currentUser);
        }
    }
}