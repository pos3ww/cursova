using CursovaRobota.DB.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursovaRobota.DB
{
    public class DbContext
    {
        public List<ItemEntity> Items { get; set; }
        public List<UserEntity> Users { get; set; }
       
        public DbContext()
        {
            Items = new List<ItemEntity> { 
                    new ItemEntity{Id=1, Name="Red Bionicle", Price=300.0, Stock=34 },
                    new ItemEntity{Id=2, Name="Blue Bionicle", Price=240.0, Stock=11 },
                    new ItemEntity{Id=3, Name="Green Bionicle", Price=195.7, Stock=21 },
                    new ItemEntity{Id=4, Name="Yellow Bionicle", Price=300.0, Stock=24 }};
            Users = new List<UserEntity>
            {
                new UserEntity{UserName="21Savage", Balance=0.0, Id=1, Password="ADijojs0S", PurchasedItems=new List<PurchasedItemsEntity> {new PurchasedItemsEntity{ItemName="Red Bionicle", Price=900.0, Quantity=3 },new PurchasedItemsEntity{ItemName="Red Bionicle", Price=900.0, Quantity=3 } } },
                new UserEntity{UserName="Empress", Balance=211.0, Id=2, Password="q21ojs3S", PurchasedItems=new List<PurchasedItemsEntity> { } },
                new UserEntity{UserName="Vika", Balance=3240.0, Id=3, Password="12345", PurchasedItems=new List<PurchasedItemsEntity> { } }
            };
          
        }
    }
}
