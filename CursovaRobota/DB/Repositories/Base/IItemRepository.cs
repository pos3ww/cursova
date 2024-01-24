using CursovaRobota.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB.Repositories.Base
{
    public interface IItemRepository
    {
        public IEnumerable<ItemEntity> Read();
        public void Update(ItemEntity item);

    }
}
