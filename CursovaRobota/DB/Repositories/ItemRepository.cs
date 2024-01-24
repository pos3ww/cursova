using CursovaRobota.DB.Entities;
using CursovaRobota.DB.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB.Repositories
{
    public class ItemRepository : IItemRepository
    {
        private DbContext context;
        public ItemRepository(DbContext context)
        {
            this.context = context;
        }

        public IEnumerable<ItemEntity> Read()
        {
            return context.Items;
        }

        public void Update(ItemEntity item)
        {
            var itemUpdate = context.Items.Find(x => x.Name == item.Name);
            itemUpdate.Stock = item.Stock;
        }
    }
}
