using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB.Entities
{
    public class UserEntity
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public double Balance { get; set; }
        public string Password { get; set; }
        public IList<PurchasedItemsEntity> PurchasedItems { get; set; }
    }
}
