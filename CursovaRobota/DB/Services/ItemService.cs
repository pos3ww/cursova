using CursovaRobota.DB.Entities;
using CursovaRobota.DB.Repositories;
using CursovaRobota.DB.Repositories.Base;
using CursovaRobota.DB.Services.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB.Services
{
    public class ItemService : IItemService
    {
        private IItemRepository itemRepository;
        public ItemService(DbContext context)
        {
            itemRepository = new ItemRepository(context);
        }

        public void BuyItem(ItemEntity item, int quantity)
        {
            item.Stock-=quantity;
            itemRepository.Update(item);
        }

        public void DisplayItems()
        {
            foreach(var item in itemRepository.Read())
            {
                Console.WriteLine($"Item Id: {item.Id}, Item: {item.Name}, Price: {item.Price}, Stock: {item.Stock}");
            }
        }

        public ItemEntity GetItemEntity(int id)
        {
            var item = itemRepository.Read().ToList().Find(x => x.Id == id);
            return item;
        }
    }
}
