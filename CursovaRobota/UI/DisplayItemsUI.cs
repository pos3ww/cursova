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
    public class DisplayItemsUI : IUserInterface
    {
        private IItemService itemService;
        public void Action(DbContext context, User currentUser)
        {
            Console.WriteLine("");
            itemService = new ItemService(context);
            itemService.DisplayItems();
        }

        public void Description()
        {
            Console.WriteLine("Display items");
        }
    }
}
