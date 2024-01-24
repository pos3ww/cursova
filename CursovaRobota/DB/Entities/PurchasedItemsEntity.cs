using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB.Entities
{
    public class PurchasedItemsEntity
    {
        public string ItemName { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}
