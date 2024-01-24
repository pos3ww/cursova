using CursovaRobota.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB.Services.Base
{
    public interface IItemService
    {
        public void DisplayItems();
        public ItemEntity GetItemEntity(int id);
        public void BuyItem(ItemEntity item, int quantity);
    }
}
